using HIPS.HSPS.Interface.Persistence.Web;
using HSPS.Web.IServices;
using HSPS.Web.Model.Models.Extensions;
using HSPS.Web.Repository;


namespace HSPS.Web.Services;

public class ReportServices : IReportServices
{
    /// <summary>
    /// 根据条件搜索报告信息
    /// </summary>
    /// <param name="condition"></param>
    /// <returns></returns>
    public Pager<Model.Models.Extensions.Report> SearchReport(SearchCondition condition)
    {
        ConditionReport searchResult = InterfaceObjectHelper.CallMethod<SearchReport, ConditionReport>(RemotingInterfaceService.MtReportService.SearchReports, (SearchReport)condition);

        if (searchResult != null && searchResult.ReportContexts.Count() > 0)
        {
            Pager<Model.Models.Extensions.Report> result = new Pager<Model.Models.Extensions.Report>();
            List<Model.Models.Extensions.Report> list = searchResult.ReportContexts.CastExtension<Model.Models.Extensions.Report>().ToList();

            result.PageIndex = condition.PageIndex.Value;
            result.PageSize = condition.PageSize.Value;
            result.Result = list;
            result.TotalCount = searchResult.QueryPage.PageTotal.Value;

            //model.success = true;
            //model.msg = "获取成功";
            //model.response = result;

            return result;
        }
        return null;
    }







}
