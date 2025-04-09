using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSPS.Web.Model.Enum;

/// <summary>
/// 枚举转换类
/// </summary>
public class EnumDescriptionAttribute
{
    private readonly string _description;
    /// <summary>
    /// 枚举项描述，用于绑定下拉框时的文本
    /// </summary>
    public string Description
    {
        get { return _description; }
    }

    private readonly bool _isShow;
    /// <summary>
    /// 是否显示
    /// </summary>
    public bool IsShow
    {
        get { return _isShow; }
    }

    private readonly bool _isDefault;
    /// <summary>
    /// 是否默认
    /// </summary>
    public bool IsDefault
    {
        get { return _isDefault; }
    }

    private readonly string _customSign;
    /// <summary>
    /// 自定义标识
    /// </summary>
    public string CustomSign
    {
        get { return _customSign; }
    }


    public EnumDescriptionAttribute(string description, string customSign, bool isShow, bool isDefault)
    {
        this._description = description;
        this._isShow = isShow;
        this._customSign = customSign;
        this._isDefault = isDefault;
    }

    public EnumDescriptionAttribute(string description, string customSign, bool isShow)
    {
        this._description = description;
        this._isShow = isShow;
        this._customSign = customSign;
    }

    public EnumDescriptionAttribute(string description, bool isShow)
    {
        this._description = description;
        this._isShow = isShow;
    }
}

