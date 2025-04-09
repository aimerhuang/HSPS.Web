using HIPS.HSPS.Interface.Persistence.Web;
using HSPS.Web.IServices.BASE;

namespace HSPS.Web.IServices;

public interface IReportTypeServices : IBaseServices<ReportType>
{
    /// <summary>
    /// 添加报告类别
    /// </summary>
    /// <param name="reportType"></param>
    /// <returns></returns>
    void AddReportType(Model.Models.Extensions.ReportType reportType);

    /// <summary>
    /// 删除报告类别
    /// </summary>
    /// <param name="reportTypeID"></param>
    /// <returns></returns>
    void DeleteReportType(int reportTypeID);

    /// <summary>
    /// 根据科室获取所有报告类别
    /// </summary>
    /// <param name="departmentID"></param>
    /// <returns></returns>
    //IEnumerable<Model.Models.Extensions.ReportType> GetReportTypesByDepartment(int departmentID);
    Task<List<ReportType>> GetReportTypesByDepartment(int departmentid);

    /// <summary>
    /// 修改报告类别
    /// </summary>
    /// <param name="reportType"></param>
    /// <returns></returns>
    void UpdateReportType(Model.Models.Extensions.ReportType reportType);


    /// <summary>
    /// 获取报告类别列表
    /// </summary>
    /// <param name="coverImageInfo"></param>
    IEnumerable<Model.Models.Extensions.ReportType> GetReportTypes();

    /// <summary>
    /// 根据科室ID集合获取需要审核的报告
    /// </summary>
    /// <returns></returns>
    IEnumerable<Model.Models.Extensions.ReportType> GetAuditingReportTypesByDepartment(List<int> departmentIDList);
    /// <summary>
    /// 获取封面类别
    /// </summary>
    /// <param name="reportTypeID"></param>
    /// <returns></returns>
    //IEnumerable<CoverType> GetCoverType(int reportTypeID);
    /// <summary>
    /// 添加封面类别
    /// </summary>
    /// <param name="reportTypeID"></param>
    /// <param name="coverName"></param>
    /// <returns></returns>
    //int AddCoverType(int reportTypeID, string coverName);
    /// <summary>
    /// 修改封面类别
    /// </summary>
    /// <param name="id"></param>
    /// <param name="coverName"></param>
    /// <returns></returns>
    //int UpdateCoverType(int id, string coverName);
    /// <summary>
    /// 删除封面类别
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    //int DeleteCoverType(string coverType, int coverTypeId, int reportTypeId);
    /// <summary>
    /// 查询报告类别名称
    /// </summary>
    /// <param name="reporttypeid"></param>
    /// <returns></returns>
    Task<List<ReportType>> GetReportTypeByID(int reporttypeid);
}
