namespace HSPS.Web.Common;

public static class EnumHelper
{
    /// <summary>
    /// 将枚举值转换成枚举类型
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="value"></param>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    public static TResult ParseEnum<TResult>(this Enum value, TResult defaultValue)
        where TResult : struct
    {
        return ParseEnumByName<TResult>(value, defaultValue);
    }

    /// <summary>
    /// 将枚举值转换成枚举类型
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="value"></param>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    public static TResult ParseEnumByName<TResult>(this Enum value, TResult defaultValue)
        where TResult : struct
    {
        try
        {
            return (TResult)Enum.Parse(typeof(TResult), value.ToString());
        }
        catch (Exception ex)
        {
            //LogServicesHelper.Error(string.Format("将{0}转换成{1}类型出现异常", value, typeof(TResult).Name), ex);
            return defaultValue;
        }
    }
}

