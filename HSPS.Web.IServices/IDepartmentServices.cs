
using Entities;
using HSPS.Web.IServices.BASE;
using HSPS.Web.Model.Models;
using HSPS.Web.Model;

namespace HSPS.Web.IServices;

/// <summary>
/// 科室接口
/// </summary>
public interface IDepartmentServices : IBaseServices<Department>
{
    /// <summary>
    /// 根据id获取科室
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<List<Department>> GetDepartmentById(int id);

    /// <summary>
    /// 获取所有科室
    /// </summary>
    /// <returns></returns>
    Task<PageModel<Department>> LoadPageList(int startPage, int pageSize, DepartmentQueryModel model);

    /// <summary>
    /// 获取所有科室id
    /// </summary>
    /// <returns></returns>
    Task<List<Department>> GetDepartmentIds();

}
