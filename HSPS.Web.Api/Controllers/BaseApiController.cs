using HSPS.Web.Model;
using Microsoft.AspNetCore.Mvc;

namespace HSPS.Web.Controllers
{
    /// <summary>
    /// 父类控制器方法
    /// </summary>
    public class BaseApiController : Controller
    {
        /// <summary>
        /// 带类型返回成功父类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        [NonAction]
        public MessageModel<T> Success<T>(T data, string msg = "成功")
        {
            return new MessageModel<T>()
            {
                success = true,
                msg = msg,
                response = data,
            };
        }

        /// <summary>
        /// 返回成功状态父类
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        [NonAction]
        public MessageModel Success(string msg = "成功")
        {
            return new MessageModel()
            {
                success = true,
                msg = msg,
                response = null,
            };
        }

        /// <summary>
        /// 返回失败状态父类
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [NonAction]
        public MessageModel<string> Failed(string msg = "失败", int status = 500)
        {
            return new MessageModel<string>()
            {
                success = false,
                status = status,
                msg = msg,
                response = null,
            };
        }

        /// <summary>
        /// 带类型返回失败
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="msg"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [NonAction]
        public MessageModel<T> Failed<T>(string msg = "失败", int status = 500)
        {
            return new MessageModel<T>()
            {
                success = false,
                status = status,
                msg = msg,
                response = default,
            };
        }

        /// <summary>
        /// 多数据分页返回成功
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="page">页数</param>
        /// <param name="dataCount">数量</param>
        /// <param name="pageSize">页数</param>
        /// <param name="data">数据</param>
        /// <param name="pageCount"></param>
        /// <param name="msg">状态</param>
        /// <returns></returns>
        [NonAction]
        public MessageModel<PageModel<T>> SuccessPage<T>(int page, int dataCount, int pageSize, List<T> data,
            int pageCount, string msg = "获取成功")
        {
            return new MessageModel<PageModel<T>>()
            {
                success = true,
                msg = msg,
                response = new PageModel<T>(page, dataCount, pageSize, data)
            };
        }

        /// <summary>
        /// 单类型分页返回成功
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageModel"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        [NonAction]
        public MessageModel<PageModel<T>> SuccessPage<T>(PageModel<T> pageModel, string msg = "获取成功")
        {
            return new MessageModel<PageModel<T>>()
            {
                success = true,
                msg = msg,
                response = pageModel
            };
        }


    }
}
