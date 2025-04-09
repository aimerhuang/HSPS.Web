using HSPS.Web.Model.Models.Extensions;
using HSPS.Web.Model.Models;

namespace HSPS.Web.IServices
{
    public interface IReportServices
    {
        Pager<Report> SearchReport(SearchCondition condition);
    }
}
