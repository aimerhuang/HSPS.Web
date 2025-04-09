using Entities;
using HSPS.Web.IServices;
using HSPS.Web.Model;
using HSPS.Web.Model.Models;
using HSPS.Web.Services.BASE;
using System.Linq.Expressions;

namespace HSPS.Web.Services;

public class DepartmentServices : BaseServices<Department>, IDepartmentServices
{
    public async Task<List<Department>> GetDepartmentById(int id)
    {
        return await base.Query(u => u.ID == id);
    }

    public async Task<PageModel<Department>> LoadPageList(int startPage, int pageSize, DepartmentQueryModel model)
    {
        PageModel<Department> pageModel = new PageModel<Department>();
        Expression<Func<Department, bool>>? expression = e => true;

        if (model.Name != null)
            expression = expression.And(t => t.Name.Contains(model.Name));

        if (model.Host != null)
            expression = expression.And(t => t.Host.Contains(model.Host));

        if (model.Port != null)
            expression = expression.And(t => t.Port == model.Port);

        var PageModeluser = await base.QueryPage(expression, startPage, pageSize, model?.Orderby?.ToLower() ?? null);
        return PageModeluser;
    }

    public async Task<List<Department>> GetDepartmentIds()
    {
        return await base.Query(u => u.ID > 0);
    }

}
