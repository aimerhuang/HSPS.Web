using Entities;
using HSPS.Web.IServices;
using HSPS.Web.Model.Dtos;
using HSPS.Web.Model;
using HSPS.Web.Services.BASE;
using System.Linq.Expressions;
using HSPS.Web.Repository.BASE;
using AutoMapper;
using HSPS.Web.Model.Models;
using HSPS.Web.Common.HttpContextUser;
using HSPS.Web.Repository;

namespace HSPS.Web.Services;


/// <summary>
/// 权限服务
/// </summary>
public class PermissionServices : BaseServices<Permission>, IPermissionServices
{
    readonly IBaseRepository<Permission> _permissionRepository;
    readonly IBaseRepository<UserRoleRelation> _roleRelationRepository;
    //readonly IBaseRepository<roleper>
    readonly IUser _user;
    private IMapper _mapper;
    public PermissionServices(IBaseRepository<Permission> permissionRepository, IBaseRepository<UserRoleRelation> roleRelationRepository, IUser user, IMapper mapper)
    {
        _mapper = mapper;
        _user = user;
        _permissionRepository = permissionRepository;
        _roleRelationRepository = roleRelationRepository;
    }

    public async Task<PageModel<PermissionDto>> LoadPageList(int startPage, int pageSize, PermissionQueryModel model)
    {
        PageModel<PermissionDto> pageModel = new PageModel<PermissionDto>();
        Expression<Func<Permission, bool>>? expression = e => true;

        if (model.Name != null)
            expression = expression.And(t => t.Name.Contains(model.Name));

        if (model.Code != null)
            expression = expression.And(t => t.Code == model.Code);

        var data = await _permissionRepository.Db.Queryable<Permission>()
            .Includes(t => t.Resource, r => r.Module)
            .Where(expression)
            //.Select(x => new PermissionDto { Resource = x.Resource }, true)
            .ToListAsync();

        data = data.Skip((startPage - 1) * pageSize).Take(pageSize).ToList();

        List<PermissionDto> userDtos = _mapper.Map<List<PermissionDto>>(data);
        pageModel.data = userDtos;
        pageModel.dataCount = data.Count;
        pageModel.page = startPage;
        pageModel.PageSize = pageSize;

        return pageModel;
    }

    public async Task<List<Permission>> GetById(int id)
    {
        return await base.Query(t => t.ID > 0 && t.ID == id);
    }



    /// <summary>
    /// 登录
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    //public bool Login(string username, string password)
    //{
    //    HIPS.HSPS.Interface.Persistence.Web.User user=new HIPS.HSPS.Interface.Persistence.Web.User {
    //        UserName = username,
    //        Password = password
    //    };

    //    return InterfaceObjectHelper.CallMethod(RemotingInterfaceService.MtPermissionControlService.Login,user);
    //}

    ///// <summary>
    ///// 登录成功
    ///// </summary>
    ///// <param name="username"></param>
    ///// <param name="password"></param>
    ///// <returns></returns>
    //public bool LoginSuccess(string username)
    //{
    //    return InterfaceObjectHelper.CallMethod<string, bool>(RemotingInterfaceService.MtPermissionControlService.LoginSuccess, username);
    //}

    ///// <summary>
    ///// 获取用户权限
    ///// </summary>
    ///// <param name="username"></param>
    ///// <returns></returns>
    //public IEnumerable<Permission> GetUserPermission(string username)
    //{
    //    var permissionList = InterfaceObjectHelper.CallMethod<string, IEnumerable<HIPS.HSPS.Interface.Persistence.Web.Permission>>(RemotingInterfaceService.MtPermissionControlService.GetUserPermissions, username);
    //    if (permissionList != null)
    //    {
    //        return permissionList.CastExtension<Permission>();
    //    }
    //    return null;
    //}


    ///// <summary>
    ///// 获取所有的权限，用于给用户配置权限
    ///// </summary>
    ///// <returns></returns>
    public IEnumerable<Permission> GetAllPermissions()
    {
        var permissionList = InterfaceObjectHelper.CallMethod<DBNull, IEnumerable<HIPS.HSPS.Interface.Persistence.Web.Permission>>(RemotingInterfaceService.MtPermissionControlService.GetPermissions, DBNull.Value);//DBNull.Value
        if (permissionList != null)
        {
            return permissionList.CastExtension<Permission>();
        }
        return null;
    }

}
