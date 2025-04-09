using HSPS.Web.Controllers;
using HSPS.Web.IServices;
using Microsoft.AspNetCore.Mvc;
using HSPS.Web.Repository.UnitOfWorks;
using HSPS.Web.AuthHelper.OverWrite;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using HSPS.Web.Model.Dtos;
using HSPS.Web.Common;
using HSPS.Web.Common.Helper;
using Entities;
using StackExchange.Profiling;
using Serilog;
using Newtonsoft.Json;
using HSPS.Web.Model;
using HSPS.Web.Models;
using Aspose.Pdf;

namespace HSPS.Web.Api.Controllers;

/// <summary>
/// 用户
/// </summary>
[ApiController]
[Route("api/[controller]/[action]")]
public class UserController : BaseApiController
{
    private readonly IUserServices _userServices;
    private readonly IPermissionServices _permissionServices;
    private readonly IDepartmentServices _departmentServices;
    private readonly IReportTypeServices _reportTypeServices;
    private readonly ILogger<UserController> _logger;
    readonly IUnitOfWorkManage _unitOfWorkManage;
    readonly IMapper _mapper;

    /// <summary>
    /// 构造函数
    /// </summary>
    public UserController(IUnitOfWorkManage unitOfWorkManage,
        IPermissionServices permissionServices,
        IUserServices userServices,
        IDepartmentServices departmentServices,
        IReportTypeServices reportTypeServices,
        ILogger<UserController> logger,
        IMapper mapper)
    {
        _userServices = userServices;
        _unitOfWorkManage = unitOfWorkManage;
        _permissionServices = permissionServices;
        _departmentServices = departmentServices;
        _reportTypeServices = reportTypeServices;
        _logger = logger;
        _mapper = mapper;
    }



    #region 查

    /// <summary>
    /// 根据token获取用户详情
    /// 【无权限】
    /// </summary>
    /// <param name="token">token令牌</param>
    /// <returns></returns>
    [HttpGet]
    [AllowAnonymous]
    public async Task<MessageModel<UserDto>> GetInfoByToken(string token)
    {
        var data = new MessageModel<UserDto>();
        if (!string.IsNullOrEmpty(token))
        {
            var tokenModel = JwtHelper.SerializeJwt(token);
            if (tokenModel != null && tokenModel.Uid > 0)
            {
                var userinfo = await _userServices.GetUserById(tokenModel.Uid.ObjToInt());
                if (userinfo != null)
                {
                    data.response = _mapper.Map<UserDto>(userinfo.First());
                    data.success = true;
                    data.msg = "获取成功";
                }
            }
        }

        return data;
    }

    /// <summary>
    /// 获取用户
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<MessageModel<List<UserDto>>> Get()
    {
        var user = await _userServices.GetUser();
        //Expression<Func<User, bool>> whereExpression = a => true;
        var data = new MessageModel<List<UserDto>>();
        data.success = true;
        data.status = 200;
        data.response = _mapper.Map<List<UserDto>>(user);
        return data;
    }
    /// <summary>
    /// 根据登录名获取用户是否存在
    /// </summary>
    /// <param name="username">用户登陆名</param>
    /// <returns></returns>
    [HttpGet]
    public MessageModel<bool> IsExists(string username)
    {
        var data = new MessageModel<bool>();
        data.success = true;
        data.status = 200;
        var user = _userServices.GetUserByName(username);
        data.response = user.IsNotEmptyOrNull() ? true : false;
        return data;
    }

    /// <summary>
    /// 获取用户列表
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<MessageModel<PageModel<UserDto>>> LoadPageList([FromQuery] UserQueryModel model)
    {
        try
        {
            Log.Information($"LoadPageList入参:{JsonConvert.SerializeObject(model)}");
            _logger.LogInformation($"LoadPageList入参:{JsonConvert.SerializeObject(model)}");
            using (MiniProfiler.Current.Step("开始获取用户列表"))
            {
                var list = await _userServices.LoadPageList(model.StartPage ?? 1, model.PageSize ?? 20, model);
                var adminUser = AppSettings.app("WebManage", "SuperAdministrator");
                if (list != null && list.dataCount > 0)
                {
                    MiniProfiler.Current.Step("管理员赋予所有权限");
                    foreach (var item in list.data)
                    {
                        //管理员设置所有科室权限
                        if (item.UserName == adminUser)
                        {
                            var dep = await _departmentServices.GetDepartmentIds();

                        }
                    }
                    return Success(list);
                }
            }
            return Failed<PageModel<UserDto>>("未查询到数据");
        }
        catch (Exception ex)
        {
            Log.Error("获取用户列表异常：" + ex);
            _logger.LogError("获取用户列表异常：" + ex);
            return Failed<PageModel<UserDto>>("获取用户列表异常：" + ex);
        }
        

    }


    /// <summary>
    /// 获取用户列表
    /// </summary>
    /// <returns></returns>
    //[HttpGet]

    //public MessageModel<List<User>> GetAllUser()
    //{
    //var data = new MessageModel<List<User>>();
    //data.success = true;
    //data.status = 200;
    //var user = _userServices.GetAllUsers();
    ////超级管理员特殊处理
    //var adminUser = AppSettings.app("WebManage", "SuperAdministrator");
    //var superAdminUser = user.FirstOrDefault(t => t.UserName == adminUser);
    //if (superAdminUser != null)
    //{
    //    //超级管理员显示所有科室
    //    var deptList = _departmentServices.GetDepartments();
    //    var deptName = "";
    //    superAdminUser.Departments = deptList;
    //    if (deptList != null && deptList.Count() > 0)
    //    {
    //        foreach (var item in deptList)
    //        {
    //            deptName += item.Name + ",";
    //        }
    //        deptName = deptName.Substring(0, deptName.Length - 1);
    //        superAdminUser.DepartmentText = deptName;
    //    }

    //}
    //if (user.Any(t => t.ClinicalDepartmentIds != null))
    //{
    //    //报告类别显示
    //    var reporttypetext = "";
    //    foreach (var item in user)
    //    {
    //        if (item.ClinicalDepartmentIds != null)
    //        {
    //            foreach (var item2 in item.ClinicalDepartmentIds)
    //            {
    //                var typename = _reportTypeServices.GetReportTypeByID(item2).Result.FirstOrDefault().Name;
    //                reporttypetext += typename + ",";
    //            }
    //            reporttypetext = reporttypetext.Substring(0, reporttypetext.Length - 1);
    //            item.ClinicalDepartmentText = reporttypetext;
    //        }
    //    }
    //}
    //data.response = user.ToList();
    //return data;
    //}




    #endregion

    #region 改
    /// <summary>
    /// 修改用户 wcf 未通
    /// </summary>
    /// <param name="updateUser">用户</param>
    /// <returns></returns>
    [HttpPost]
    public MessageModel<string> UpdateUser(User updateUser)
    {
        return Failed("修改失败");
        //var data = new MessageModel<string>();
        //data.success = true;
        //data.status = 200;
        //_userServices.UpdateUser(updateUser);
        //data.response = "修改成功";
        //return data;
    }

    /// <summary>
    /// 修改用户密码 sqlsugar
    /// </summary>
    /// <param name="userId">用户id</param>
    /// <param name="userName">登录名</param>
    /// <param name="pass">新密码</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<MessageModel<string>> UpdateUserPassword(int userId, string userName, string pass)
    {
        var user = await _userServices.GetUserById(userId);
        if (user != null && user.Count() > 0)
        {
            var userdto = user.FirstOrDefault();
            userdto.Password = MD5Helper.MD5Encrypt32(pass);
            var result = await _userServices.UpdateUserPassword(userdto);
            if (result)
                return Success<string>("修改成功");
            else
                return Success<string>("修改失败");
        }
        return Failed<string>("修改失败！未找到用户！");
    }



    #endregion

    #region 增
    /// <summary>
    /// 添加用户 wcf 未通
    /// </summary>
    /// <param name="addUser">用户</param>
    /// <returns></returns>
    [HttpPost]
    public MessageModel<string> InsertUser(Model.Models.Extensions.User addUser)
    {
        return Failed("添加失败");
        //var data = new MessageModel<string>();
        //data.success = true;
        //data.status = 200;
        //_userServices.InsertUser(addUser);
        //data.response = "添加成功";
        //return data;
    }

    /// <summary>
    /// 添加修改用户审核权限 wcf 未通
    /// </summary>
    /// <param name="json">用户选择所有报告类别集合序列化的json</param>
    /// <returns></returns>
    [HttpPost]
    public MessageModel<string> AddOrUpdateUserAuditRanges(string json)
    {
        return Failed("添加失败");
        //var data = new MessageModel<string>();
        //data.success = true;
        //data.status = 200;
        //if (JsonHelper.IsJson(json))
        //{
        //    var userList = JsonHelper.ParseFormByJson<List<AddUserAuditRangeModel>>(json);
        //    List<AddUserAuditRangeModel> _userAuditRange = new List<AddUserAuditRangeModel>();
        //    foreach (var item in userList)
        //    {
        //        if (item.ID.IsNotEmptyOrNull() && item.AuditLevel.IsNotEmptyOrNull())
        //        {
        //            AddUserAuditRangeModel userAuditRange = new AddUserAuditRangeModel();
        //            userAuditRange.UserID = item.UserID;
        //            userAuditRange.ReportTypeID = item.ReportTypeID;
        //            userAuditRange.StationID = item.StationID.TrimEnd(',');
        //            userAuditRange.AuditLevel = item.AuditLevel.TrimEnd(',');
        //            userAuditRange.ID = item.ID.IsNotEmptyOrNull() ? item.ID : userAuditRange.ID;
        //            _userAuditRange.Add(userAuditRange);
        //        }
        //    }
        //    _userServices.AddOrUpdateUserAuditRanges(_userAuditRange);
        //}
        //data.response = "添加成功";
        //return data;
    }
    #endregion

    /// <summary>
    /// 根据用户id删除用户 wcf 未通
    /// </summary>
    /// <param name="ID">用户id</param>
    /// <returns></returns>
    [HttpPost]
    public MessageModel<string> DeleteUserByID(int ID)
    {
        return Failed("删除失败");
        var data = new MessageModel<string>();
        data.success = true;
        data.status = 200;
        //_userServices.DeleteUser(new List<int>() { ID });
        data.response = "删除成功";
        return data;
    }


    /// <summary>
    /// 删除用户
    /// </summary>
    /// <param name="user">用户</param>
    /// <returns></returns>
    //[HttpPost]
    //public MessageModel<string> DeleteUser(User user)
    //{
    //    var data = new MessageModel<string>();
    //    data.success = true;
    //    data.status = 200;

    //    //超级管理员特殊处理
    //    var adminUser = AppSettings.app("WebManage", "SuperAdministrator");
    //    if (user.UserName == adminUser)
    //    {
    //        return Failed("超级管理员（" + adminUser + "）不能删除！");
    //    }
    //    //_userServices.DeleteUser(new List<int>() { user.ID });
    //    data.response = "删除成功！";
    //    return data;
    //}

}


