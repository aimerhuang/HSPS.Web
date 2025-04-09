
using AutoMapper;
using Entities;
using HSPS.Web.IServices;
using HSPS.Web.Model;
using HSPS.Web.Model.Dtos;
using HSPS.Web.Models;
using HSPS.Web.Repository.BASE;
using HSPS.Web.Services.BASE;
using System.Linq.Expressions;

namespace HSPS.Web.Services;

public class UserServices : BaseServices<User>, IUserServices
{
    readonly IBaseRepository<User> _userRepository;
    private IMapper _mapper;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="userRepository"></param>
    /// <param name="mapper"></param>
    public UserServices(IBaseRepository<User> userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<List<User>> GetUserById(int id)
    {
        return await base.Query(u => u.ID == id);
    }

    public async Task<List<User>> GetUser()
    {
        var userlist = await base.Query(u => u.ID > 0);
        return userlist;
    }

    public Task<List<User>> GetUserByName(string name)
    {
        var user = base.Query(u => u.UserName == name);
        return user;
    }

    public async Task<bool> UpdateUserPassword(User user)
    {
        return await base.Update(user);
    }

    public async Task<List<User>> Login(string name, string password)
    {
        var user = await base.Query(t => t.UserName == name && t.Password == password);
        return user;
    }


    /// <summary>
    /// 分页获取用户
    /// 导航查询
    /// </summary>
    /// <param name="model">查询条件</param>
    /// <returns></returns>
    public async Task<PageModel<UserDto>> LoadPageList(int startPage, int pageSize, UserQueryModel model)
    {
        PageModel<UserDto> pageModel = new PageModel<UserDto>();
        Expression<Func<User, bool>>? expression = e => true;

        if (model.Name != null)
            expression = expression.And(t => t.UserName.Contains(model.Name) || t.Name.Contains(model.Name));

        if (model.Enabled != null)
            expression = expression.And(t => t.Enabled == model.Enabled);

        var data = await _userRepository.Db.Queryable<User>()
            .Includes(t => t.userDepartmentRelations)
            .Includes(t => t.userRoleRelations)
            .Includes(t => t.userReporttypeIdRelations)
        .Where(expression)
        .ToListAsync();

        data = data.Skip((startPage - 1) * pageSize).Take(pageSize).ToList();

        List<UserDto> userDtos = _mapper.Map<List<UserDto>>(data);
        pageModel.data = userDtos;
        pageModel.dataCount = data.Count;
        pageModel.page = startPage;
        pageModel.PageSize = pageSize;

        return pageModel;
    }


}


