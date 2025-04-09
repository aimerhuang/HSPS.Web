using Entities;
using HSPS.Web.IServices.BASE;
using HSPS.Web.Model;
using HSPS.Web.Model.Dtos;
using HSPS.Web.Models;


namespace HSPS.Web.IServices;
public interface IUserServices : IBaseServices<User>
{
    /// <summary>
    /// 根据id获取用户
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<List<User>> GetUserById(int id);
    /// <summary>
    /// 获取所有用户
    /// </summary>
    /// <returns></returns>
    Task<List<User>> GetUser();
    /// <summary>
    /// 根据姓名获取所有用户
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    Task<List<User>> GetUserByName(string name);

    /// <summary>
    /// 修改用户密码
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<bool> UpdateUserPassword(User user);

    /// <summary>
    /// 分页获取用户
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    Task<PageModel<UserDto>> LoadPageList(int startPage, int pageSize,UserQueryModel model);

    /// <summary>
    /// 登陆方法
    /// </summary>
    /// <param name="name"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    Task<List<User>> Login(string name, string password);
}

