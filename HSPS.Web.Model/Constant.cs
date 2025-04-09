

namespace HSPS.Web.Model;

public static class Constant
{
    /// <summary>
    /// 报告图片默认的格式
    /// </summary>
    public const string DEFAULT_REPORT_IMAGE_EXTENSION = ".jpeg";

    /// <summary>
    /// 报告原始文件XPS格式
    /// </summary>
    public const string DEFAULT_REPORT_XPS_EXTENSION = ".xps";

    /// <summary>
    /// 报告原始文件PDF格式
    /// </summary>
    public const string DEFAULT_REPORT_PDF_EXTENSION = ".pdf";
    /// <summary>
    /// 胶片略缩图片默认的格式
    /// </summary>
    public const string DEFAULT_REPORT_FILM_EXTENSION = ".dcm";

    /// <summary>
    /// 胶片略缩图片默认的格式
    /// </summary>
    public const string DEFAULT_REPORT_FILMSMALLIMAGE_EXTENSION = ".jpg";

    /// <summary>
    /// 多胶片时设置规则区域图的默认格式
    /// </summary>
    public const string DEFAULT_REPORT_MANAYFILMIMAGE_EXTENSION = ".bmp";

    /// <summary>
    /// 报表文本默认的格式
    /// </summary>
    public const string DEFAULT_REPORT_TXT_EXTENSION = ".txt";

    /// <summary>
    /// 数据处理成功，Handler页默认写入到前台的标识
    /// </summary>
    public const string OPERATION_SUCCESS_DEFAULT_MSG = "1";

    /// <summary>
    /// 数据处理失败，Handler页默认写入到前台的标识
    /// </summary>
    public const string OPERATION_ERROR_DEFAULT_MSG = "0";

    /// <summary>
    /// 列表控件数据为空时，默认写入到前台的内容，避免IE浏览器下easyui datagrid控件报错
    /// </summary>
    public const string DATA_EMPTY_DEFAULT_MSG = "[]";

    /// <summary>
    /// 用户登陆后，记录用户名称的Session名称
    /// </summary>
    public const string SESSION_USER_USERNAME = "HSPS_User_UserName";
    /// <summary>
    /// 用户登陆后，记录用户ID的Session名称
    /// </summary>
    public const string SESSION_USER_ID = "HSPS_User_ID";
    /// <summary>
    /// 用户登陆后，记录用户姓名的Session名称
    /// </summary>
    public const string SESSION_USER_NAME = "HSPS_User_Name";
    /// <summary>
    /// 记录用户的快捷条件
    /// </summary>
    public const string SESSION_QUERY_CACHE = "HSPS_Query_Cache";
    /// <summary>
    /// 用户登陆后，记录用户权限的Cache
    /// </summary>
    public const string CACHE_HSPS_USER_PERMISSION = "HSPS_User_Permission_Cache";
    /// <summary>
    /// 记录CodeMap的Cache
    /// </summary>
    public const string CACHE_HSPS_CODEMAP = "HSPS_CodeMap_Cache";
    /// <summary>
    /// 记录菜单数据
    /// </summary>
    public const string SESSION_MENU_DATA = "Menu_Data";
    /// <summary>
    /// 记录Main/Sub菜单数据
    /// </summary>
    public const string SESSION_MAIN_MENU_DATA = "Main_Menu_Data";
    /// <summary>
    /// 记录Tab菜单数据
    /// </summary>
    public const string SESSION_TAB_MENU_DATA = "Tab_Menu_Data";
    /// <summary>
    /// 发生错误后，记录的Session名称
    /// </summary>
    public const string SESSION_ERROR_MESSAGE = "HSPS_Error_Msg";
    /// <summary>
    /// 是否提醒过医院信息
    /// </summary>
    public const string SESSION_HOSPITAL_ALERT = "Hospital_Alert";
    /// <summary>
    /// 默认的分隔符
    /// </summary>
    public const string DEFAULT_SPLIT_SIGN = ",";
    /// <summary>
    /// app名称
    /// </summary>
    public const string DEFAULT_APP_NAME = "Web";
    /// <summary>
    /// 医院识别名
    /// </summary>
    public const string HOSPITAL_FLAG = "Hospital";
    /// <summary>
    /// 是否提醒过存储空间
    /// </summary>
    public const string SESSION_STORAGE_ALERT = "Storage_Alert";
    /// <summary>
    /// 存储识别名
    /// </summary>
    public const string STORAGE_FLAG = "Storage";
}
