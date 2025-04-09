using AutoMapper;
using HSPS.Web.Controllers;
using HSPS.Web.Model.Dtos;
using HSPS.Web.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HSPS.Web.Model.Models;
using SqlSugar;
using HSPS.Web.Common.HttpContextUser;
using HSPS.Web.Model.Models.Extensions;
using HSPS.Web.IServices;
using HSPS.Web.Common;
using HSPS.Web.IServices.BASE;
using Microsoft.IdentityModel.Logging;
using HSPS.Web.Common.Helper;

namespace HSPS.Web.Api.Controllers;

/// <summary>
/// 报告操作控制器
/// </summary>
[Produces("application/json")]
[Route("api/[controller]/[action]")]
//[AllowAnonymous]
public class ReportController : BaseApiController
{

    private readonly IReportServices _reportServices;
    private readonly IUserServices _userServices;
    private readonly IDepartmentServices _departmentServices;
    private readonly ICommonServices _commonServices;
    readonly IUser _user;
    private readonly IMapper _mapper;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="reportServices"></param>
    /// <param name="userServices"></param>
    /// <param name="departmentServices"></param>
    /// <param name="commonServices"></param>
    /// <param name="user"></param>
    /// <param name="mapper"></param>
    public ReportController(IReportServices reportServices, IUserServices userServices, IDepartmentServices departmentServices, ICommonServices commonServices, IUser user, IMapper mapper)
    {
        _reportServices = reportServices;
        _userServices = userServices;
        _departmentServices = departmentServices;
        _commonServices = commonServices;
        _user = user;
        _mapper = mapper;
    }


    /// <summary>
    /// 分页获取所有报告（wcf）
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    [Authorize]
    public MessageModel<List<ReportDto>> SearchReport([FromBody] ReportQueryModel model)
    {
        List<ReportDto> reportDto = new List<ReportDto>();
        bool suc = false;
        if (model.IsNotEmptyOrNull())
        {
            if (IsContainSqlFilter(model.BarCode))
                return Failed<List<ReportDto>>("条码号格式不正确");

            SearchCondition searchCondition = GetSearchCondition(model);

            var reportList = _reportServices.SearchReport(searchCondition);
            if (reportList != null && reportList.Result.Count > 0)
            {
                suc = true;
                reportDto = _mapper.Map<List<ReportDto>>(reportList.Result);
            }
            return new MessageModel<List<ReportDto>>()
            {
                success = suc,
                msg = suc ? "获取成功" : "获取失败",
                response = reportDto
            };
        }
        return Failed<List<ReportDto>>("入参格式不正确，请填写正确的入参");
    }

    /// <summary>
    /// 根据id获取报告图片
    /// </summary>
    /// <param name="id">主键id</param>
    /// <returns></returns>
    [HttpPost]
    [Authorize]
    public MessageModel<List<object>> GetReportImage(long id)
    {
        if (id.IsNullOrEmpty()) return Failed<List<object>>("获取不到图片!");

        try
        {
            var report = _commonServices.GetEntityByID<Report>(id);
            List<object> reportImgs = new List<object>();
            if (report.IsNotEmptyOrNull())
            {
                reportImgs = ReportFileHelper.GetReportImage(report, true);
            }
            if (reportImgs.IsNullOrEmpty())
            {
                return Failed<List<object>>("获取不到图片!");
            }
            else
            {
                return Success<List<object>>(reportImgs, "获取报告文件成功");
            }
        }
        catch (Exception)
        {
            return Failed<List<object>>("获取不到图片!");
        }

    }




    /// <summary>
    /// 获取查询条件
    /// </summary>
    /// <param name="model">条件</param>
    /// <returns></returns>
    [NonAction]
    public SearchCondition GetSearchCondition(ReportQueryModel model)
    {
        SearchCondition searchCondition = new SearchCondition();

        searchCondition.PageSize = model.PageSize.Value;
        searchCondition.PageIndex = model.PageIndex.Value;


        /*排序字段*/
        if (model.Orderby != null)
        {
            //if (!model.Orderby.Equals("CheckPart"))
            //{
            //根据页面传入的排序字段，生成数据库排序需要的字段，如下：
            searchCondition.SortItems = new List<string>() { ConvertSortNameToTableSortName(model.Orderby) };
            //}
        }
        /*排序方式*/
        if (model.Order != null)
        {
            searchCondition.IsDesc = model.Order == "desc" ? true : false;
        }

        /*条码号,是否模糊查询*/
        if (model.BarCode != null)
        {
            if (model.IsFuzzy == true)
            {
                searchCondition.Conditions = string.Format(" and (reportcontext.BarCode like ''%{0}%'' or  reportcontext.PatientName like ''%{0}%'' or reportcontext.CheckID like ''%{0}%''or reportcontext.HospitalNo like ''%{0}%'')", model.BarCode.Trim());
            }
            else
            {
                searchCondition.Conditions = string.Format(" and (reportcontext.BarCode = ''{0}'' or  reportcontext.PatientName = ''{0}'' or reportcontext.CheckID = ''{0}'' or  reportcontext.HospitalNo = ''{0}'' )", model.BarCode.Trim());
            }
        }


        /*住院号*/
        if (model.HospitalNo.IsNotEmptyOrNull())
        {
            searchCondition.Conditions += string.Format(" and reportcontext.HospitalNo = {0}", model.HospitalNo);
        }
        /*增加来源IP的条件   hkl 2023-10-17*/
        if (model.IsByStation.IsNotEmptyOrNull())
        {
            searchCondition.Conditions += string.Format(" and report.StationId in ({0})", model.IsByStation);
        }
        /*匹配状态*/
        if (model.IsMatch.IsNotEmptyOrNull())
        {
            searchCondition.IsMatch = model.IsMatch;
        }

        /*文件类型*/
        if (model.FileType.IsNotEmptyOrNull())
        {
            searchCondition.FileType = (model.FileType).ParseEnum(FileTypeEnum.Image);
        }
        /*开始时间*/
        DateTime beginDate = DateTime.Now;
        if (model.TotalTimePeriod.IsNotEmptyOrNull() && model.TotalTimePeriod.StartTime.IsNotEmptyOrNull() && DateTime.TryParse(model.TotalTimePeriod.StartTime, out beginDate))
        {
            searchCondition.TimeBegin = beginDate;
        }
        /*结束时间*/
        DateTime endDate = DateTime.Now;
        if (model.TotalTimePeriod.IsNotEmptyOrNull() && model.TotalTimePeriod.EndTime.IsNotEmptyOrNull() && DateTime.TryParse(model.TotalTimePeriod.EndTime, out endDate))
        {
            searchCondition.TimeEnd = endDate;
        }
        /*打印状态*/
        if (!string.IsNullOrEmpty(model.PrintStatus))
        {
            searchCondition.PrintStatus = (model.PrintStatus).ParseEnum(PrintStatusEnum.Unprint);

        }
        /*识别状态*/
        if (!string.IsNullOrEmpty(model.DiscernStatus))
        {
            searchCondition.DiscernStatus = (model.DiscernStatus).ParseEnum(DiscernStatusEnum.UnDiscern);

        }
        /*报告状态*/
        if (!string.IsNullOrEmpty(model.ReportStatus))
        {
            searchCondition.ReportStatus = (model.ReportStatus).ParseEnum(ReportStatusEnum.Normal);

        }
        /*查历史表或主表通过IsHistory来区分*/
        model.IsHistory = true ? searchCondition.IsHistory : searchCondition.IsHistory = false;

        /*科室过滤*/
        if (!string.IsNullOrEmpty(model.MedicalTechDepart))
        {
            var stringDepartmentList = model.MedicalTechDepart.Split(',');
            var intDepartmentList = Array.ConvertAll<string, int>(stringDepartmentList, delegate (string s) { return int.Parse(s); }).ToList();

            //根据token获取用户类别集合
            if (_user.IsNotEmptyOrNull() && _user.Name == AppSettings.app("WebManage", "SuperAdministrator"))
            {
                searchCondition.DepartmentIds = intDepartmentList;
            }
            else
            {
                var user = _userServices.GetUserByName(_user.Name);
                //if (user != null && user.Departments != null && user.Departments.Count() > 0)
                //{
                //    //用户科室列表与查询科室列表取交集
                //    var userDepartmentList = user.Departments.ToList();
                //    var userDepartmentIDList = userDepartmentList.Select(item => item.ID).ToList();
                //    if (userDepartmentIDList != null)
                //    {
                //        var intersectedList = intDepartmentList.Intersect(userDepartmentIDList).ToList();
                //        searchCondition.DepartmentIds = intersectedList;
                //    }
                //    else
                //    {
                //        searchCondition.DepartmentIds = null;
                //    }
                //}
            }
        }
        else
        {
            //其他角色根据实际的科室权限过滤
            //string examinationDpName = _departmentServices.GetExaminationDpName();//获取体检中心名字
            int notExistID = -1;//科室ID为-1，标识没有权限
            IEnumerable<int> departmentIDList = new List<int>() { notExistID };//默认都没有权限
            var user = _userServices.GetUserByName(_user.Name);
            //if (_user.IsNotEmptyOrNull() && _user.Name != AppSettings.app("WebManage", "SuperAdministrator"))
            //{
            //    if (user.Departments != null && user.Departments.Count() > 0)
            //    {
            //        var departmentList = user.Departments.ToList().FindAll(item => item.Name != examinationDpName);
            //        departmentIDList = departmentList.Select(item => item.ID).ToList();
            //    }
            //}
            //else
            //{
            //    //管理员获得所有科室
            //    var departmentList = _departmentServices.GetDepartments();
            //    if (departmentList != null)
            //    {
            //        //排除体检中心科室
            //        var department = departmentList.ToList();
            //        for (int i = 0; i < department.Count(); i++)
            //        {
            //            if (department[i].Name == examinationDpName)
            //            {
            //                department.RemoveAt(i);
            //            }
            //        }
            //        departmentIDList = department.Select(item => item.ID).ToList();
            //    }
            //}
            //searchCondition.DepartmentIds = departmentIDList;
        }

        /*院区过滤*/
        if (!string.IsNullOrEmpty(model.HospitalArea))
        {
            List<string> hAList = new List<string>();
            var hospitalArea = model.HospitalArea.Split(',');
            for (int i = 0; i < hospitalArea.Length; i++)
            {
                if (hospitalArea[i] == "空")
                {
                    hAList.Add("");
                }
                else
                {
                    hAList.Add(hospitalArea[i]);
                }

            }
            searchCondition.HospitalAreas = hAList;
        }
        else
        {
            // 按角色过滤权限
            if (_user.Name != AppSettings.app("WebManage", "SuperAdministrator"))
            {
                var user = _userServices.GetUserByName(_user.Name);
                //if (user != null && user.HospitalAreaIds != null)
                //{
                //    searchCondition.HospitalAreas = user.HospitalAreas.Select(p => p.HospitalAreaName);
                //}
            }
        }

        /*病区过滤*/
        if (!string.IsNullOrEmpty(model.PatientArea))
        {
            List<string> pAList = new List<string>();
            var patientArea = model.PatientArea.Split(',');
            for (int i = 0; i < patientArea.Length; i++)
            {
                if (patientArea[i] == "空")
                {
                    pAList.Add("");
                }
                else
                {
                    pAList.Add(patientArea[i]);
                }

            }
            searchCondition.PatientAreas = pAList;
        }
        else
        {
            // 按角色过滤权限
            if (_user.Name != AppSettings.app("WebManage", "SuperAdministrator"))
            {
                var user = _userServices.GetUserByName(_user.Name);
                //if (user != null && user.PatientAreaIds != null)
                //{
                //    searchCondition.PatientAreas = user.PatientAreas.Select(p => p.PatientAreaName);
                //}
            }
        }

        /*报告类别*/
        if (model.ReportType.IsNotEmptyOrNull())
        {
            List<int> ReportTypeList = new List<int>();
            var reportTypes = model.ReportType.TrimEnd(',').Split(',');
            for (int i = 0; i < reportTypes.Length; i++)
            {
                var typeID = 0;
                if (int.TryParse(reportTypes[i], out typeID))
                {
                    ReportTypeList.Add(typeID);
                }
            }
            searchCondition.ReportTypeIds = ReportTypeList;
        }
        else
        {
            if (_user.Name != AppSettings.app("WebManage", "SuperAdministrator"))
            {
                var user = _userServices.GetUserByName(_user.Name);
                //if (user.ClinicalDepartmentIds != null)
                //{
                //    searchCondition.ReportTypeIds = user.ClinicalDepartmentIds;
                //}
            }
        }

        return searchCondition;
    }

    /// <summary>
    /// 排序字段加上表名
    /// </summary>
    /// <param name="sortName"></param>
    /// <returns></returns>
    [NonAction]
    private string ConvertSortNameToTableSortName(string sortName)
    {
        var strRelust = "";
        switch (sortName)
        {
            case "BarCode":
                strRelust = "reportcontext.BarCode";
                break;
            case "CheckID":
                strRelust = "reportcontext.CheckID";
                break;
            case "PatientIDStr":
                strRelust = "reportcontext.hspsPatientID";//hkl 25.3.5 修改 可能报错
                break;
            case "PatientName":
                strRelust = "reportcontext.PatientName";//
                break;
            case "CheckPart":
                strRelust = "reportcontext.CheckPart";//
                break;
            case "ReportTypeName":
                strRelust = "reporttype.Name";
                break;
            case "PrintStatusName":
                strRelust = "report.PrintStatus";
                break;
            case "ReceiveTime":
                strRelust = "report.ReceiveTime";
                break;
            case "PrintLastTime":
                strRelust = "report.PrintLastTime";
                break;
            case "DiscernStatusName":
                strRelust = "report.DiscernStatus";
                break;

        }

        return strRelust;
    }

    /// <summary>
    /// 是否包含sql关键字
    /// </summary>
    /// <param name="InText"></param>
    /// <returns></returns>
    [NonAction]
    private bool IsContainSqlFilter(string InText)
    {
        string word = "and|exec|insert|select|delete|update|chr|mid|master|truncate|char|declare|join|create|drop|%|create";
        if (string.IsNullOrEmpty(InText))
        {
            return false;
        }
        var array = word.Split('|');
        foreach (string i in word.Split('|'))
        {
            if (InText.ToLower().Contains(i))
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// 获取报告的文件
    /// </summary>
    /// <param name="rc"></param>
    /// <returns></returns>
    [NonAction]
    private static string[] GetReportFiles(Report rc)
    {
        string serverFilePath = rc.ReportPath;

        if (string.IsNullOrEmpty(serverFilePath))
        {
            //LogServicesHelper.Warn(string.Format("ID为{0}的报告/胶片文件文件路径不存在", rc.ID));
            return null;
        }

        string[] files = ReportFileHelper.GetFilesName(serverFilePath);
        //判断报告文件是否存在
        if (files == null || files.Length == 0)
        {
            //LogServicesHelper.Warn(string.Format("ID为{0}的报告/胶片文件在文件服务器上不存在，文件路径：{1}", rc.ID, rc.ReportPath));
            return null;
        }

        return files;
    }
}
