
using HSPS.Web.Model.Models.Extensions;

namespace HSPS.Web.IServices.BASE;

public interface ICommonServices
{
    /// <summary>
    /// 根据ID获取实体信息
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    T GetEntityByID<T>(int id) where T : IEntity;

    /// <summary>
    /// 根据ID获取实体信息
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    T GetEntityByID<T>(long id) where T : IEntity;
}
