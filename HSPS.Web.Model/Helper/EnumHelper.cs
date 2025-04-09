using HSPS.Web.Model.Enum;
using HSPS.Web.Model.Models;
using System;


namespace HSPS.Web.Model.Helper;

public class EnumHelper
{
    public static List<TextValue> ChangeToDict(Type enumType)
    {
        var result = new List<TextValue>();
        var names = System.Enum.GetNames(enumType);
        foreach (string name in names)
        {
            var enumAttr = enumType.GetField(name).GetCustomAttributes(typeof(EnumDescriptionAttribute), false)
                        .Cast<EnumDescriptionAttribute>().FirstOrDefault();
            if (enumAttr != null && enumAttr.IsShow)
            {
                result.Add(new TextValue()
                {
                    Text = enumAttr.Description,
                    Value = ((int)System.Enum.Parse(enumType, name)).ToString()
                });
            }
        }

        return result;
    }

    /// <summary>
    /// 将枚举的Name和Description转换成TextValue集合
    /// </summary>
    /// <param name="enumType">枚举类型</param>
    /// <param name="customSign">自定义标记，用于只绑定某些枚举字段</param>
    /// <returns></returns>
    public static List<TextValue> EnumNameDescriptionToTextValueList(Type enumType, string customSign)
    {
        List<TextValue> result = new List<TextValue>();

        Array names = System.Enum.GetNames(enumType);

        foreach (string name in names)
        {
            object[] attrs = enumType.GetField(name).GetCustomAttributes(typeof(EnumDescriptionAttribute), false);
            TextValue tv = new TextValue();
            if (attrs != null && attrs.Length > 0)
            {
                EnumDescriptionAttribute descAttr = attrs[0] as EnumDescriptionAttribute;
                if (descAttr.IsShow)
                {
                    if (string.IsNullOrEmpty(descAttr.CustomSign) ||
                        string.IsNullOrEmpty(customSign) ||
                        !string.IsNullOrEmpty(descAttr.CustomSign) && !string.IsNullOrEmpty(customSign) && ("," + descAttr.CustomSign).IndexOf("," + customSign) >= 0)
                    {
                        tv.Text = descAttr.Description;
                        tv.Value = name;
                        tv.IsDefault = descAttr.IsDefault;
                        tv.CustomSign = descAttr.CustomSign;
                        result.Add(tv);
                    }
                }
            }
            else
            {
                tv.Text = name;
                tv.Value = name;
                result.Add(tv);
            }
        }
        return result;
    }

    public static string ConvertToEnumDescription<T>(T t) where T : struct
    {
        Type enumType = typeof(T);
        Array names = System.Enum.GetNames(enumType);

        foreach (string name in names)
        {
            object[] attrs = enumType.GetField(name).GetCustomAttributes(typeof(EnumDescriptionAttribute), false);
            if (attrs != null && attrs.Length > 0)
            {
                EnumDescriptionAttribute descAttr = attrs[0] as EnumDescriptionAttribute;
                if (name.Equals(t.ToString()))
                {
                    return descAttr.Description;
                }
            }
        }
        return string.Empty;
    }

    /// <summary>
    /// 将枚举的Name和Description转换成TextValue集合
    /// </summary>
    /// <param name="enumTypeName">枚举名称</param>
    /// <param name="customSign">自定义标记，用于只绑定某些枚举字段</param>
    /// <returns></returns>
    public static List<TextValue> EnumNameDescriptionToTextValueList(string enumTypeName, string customSign)
    {
        if (!string.IsNullOrEmpty(enumTypeName))
        {
            System.Reflection.Assembly asm = typeof(EnumDescriptionAttribute).Assembly;
            foreach (var type in asm.GetTypes())
            {
                if (type.Name.Equals(enumTypeName))
                {
                    return EnumHelper.EnumNameDescriptionToTextValueList(type, customSign);
                }
            }
        }
        return new List<TextValue>();
    }

    /// <summary>
    /// 将枚举的Name和Description转换成TextValue集合
    /// </summary>
    /// <param name="enumType"></param>
    /// <returns></returns>
    public static List<TextValue> EnumNameDescriptionToTextValueList(Type enumType)
    {
        return EnumNameDescriptionToTextValueList(enumType, null);
    }

    /// <summary>
    /// 加载所有的枚举Name和Description转换成TextValue集合
    /// </summary>
    /// <returns></returns>
    public static Dictionary<string, List<TextValue>> LoadAllEnumNameDescriptionTextValueList()
    {
        Dictionary<string, List<TextValue>> result = new Dictionary<string, List<TextValue>>();

        System.Reflection.Assembly assembly = System.Reflection.Assembly.GetAssembly(typeof(DiscernStatusEnum));

        foreach (var type in assembly.GetTypes())
        {
            if (type.IsEnum)
            {
                List<TextValue> tvList = EnumNameDescriptionToTextValueList(type);
                result.Add(type.Name, tvList);
            }
        }

        return result;
    }
}

public class TextValue
{
    /// <summary>
    /// 文本
    /// </summary>
    public string Text { get; set; }
    /// <summary>
    /// 自定义标记
    /// </summary>
    public string CustomSign { get; set; }
    /// <summary>
    /// 值
    /// </summary>
    public string Value { get; set; }
    /// <summary>
    /// 是否默认
    /// </summary>
    public bool IsDefault { get; set; }
}

