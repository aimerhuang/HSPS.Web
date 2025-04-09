using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace HSPS.Web.Model.Base;

public class InvalidAttribute
{
    #region 验证整型格式
    /// <summary>
    /// 验证整型格式(Post请求：将类型设置为可空:int? 才能正确显示设置的错误信息)
    /// </summary>
    public class VerifyInt : RequiredAttribute
    {
        private bool _isZero = false;
        public VerifyInt()//验证正整数
        {

        }
        public VerifyInt(bool isZero)//True为允许等于0且不是负数
        {
            _isZero = isZero;
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                //ErrorMessage = "{0}不能为空且必须是数字";
                return true;
            }
            else
            {
                if (!Int64.TryParse(value.ToString(), out long result))
                {
                    ErrorMessage = "必须是数字";
                    return false;
                }
                else
                {
                    if (!_isZero && Convert.ToInt64(value) <= 0)
                    {
                        ErrorMessage = "{0}必须大于0";
                        return false;
                    }
                    else
                    {
                        if (Convert.ToInt64(value) < 0)
                        {
                            ErrorMessage = "{0}不能小于0";
                            return false;
                        }
                    }
                }
            }

            return base.IsValid(value);
        }
    }
    #endregion

    #region 验证浮点格式
    /// <summary>
    /// 验证整型格式(Post请求：将类型设置为可空:int? 才能正确显示设置的错误信息)
    /// </summary>
    public class VerifyFloat : RequiredAttribute
    {
        private bool _isZero = false;
        public VerifyFloat()//验证正整数
        {

        }
        public VerifyFloat(bool isZero)//True为允许等于0且不是负数
        {
            _isZero = isZero;
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                //ErrorMessage = "{0}不能为空且必须是数字";
                return true;
            }
            else
            {
                if (!decimal.TryParse(value.ToString(), out decimal result))
                {
                    ErrorMessage = "必须是数字";
                    return false;
                }
                else
                {
                    if (!_isZero && Convert.ToInt32(value) <= 0)
                    {
                        ErrorMessage = "{0}必须大于0";
                        return false;
                    }
                    else
                    {
                        if (Convert.ToInt32(value) < 0)
                        {
                            ErrorMessage = "{0}不能小于0";
                            return false;
                        }
                    }
                }
            }

            return base.IsValid(value);
        }
    }
    #endregion

    #region 验证日期格式
    /// <summary>
    /// 验证日期格式(Post请求：将类型设置为可空:datetime? 才能正确显示设置的错误信息)
    /// </summary>
    public class VerifyDatetime : RequiredAttribute
    {
        private bool _isZero = false;
        public VerifyDatetime()//
        {

        }
        public VerifyDatetime(bool isZero)//True 为验证必须大于上线时间且小于当前时间
        {
            _isZero = isZero;
        }
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                ErrorMessage = "{0}不能为空且必须是日期格式";
            }
            else
            {
                if (_isZero)
                {
                    //获取配置文件中上线时间
                    //DateTime LiveOnDateTime = Convert.ToDateTime(ConfigurationManager.AppSettings["LiveOnDateTime"]);
                    //if (((DateTime)value) < LiveOnDateTime || ((DateTime)value) > DateTime.Now)
                    //{
                    //    ErrorMessage = "{0}必须大于上线时间且小于当前时间";
                    //    return false;
                    //}
                }

            }

            return base.IsValid(value);
        }
    }
    #endregion

    #region 对两个属性值的大小进行验证
    /// <summary>
    /// Specifies that the field must compare favourably with the named field, if objects to check are not of the same type
    /// false will be return
    /// </summary>
    public class CompareValuesAttribute : ValidationAttribute
    {
        /// <summary>
        /// The other property to compare to
        /// </summary>
        public string OtherProperty { get; set; }

        public CompareValues Criteria { get; set; }

        /// <summary>
        /// Creates the attribute
        /// </summary>
        /// <param name="otherProperty">The other property to compare to</param>
        public CompareValuesAttribute(string otherProperty, CompareValues criteria)
        {
            if (otherProperty == null)
                throw new ArgumentNullException("otherProperty");

            OtherProperty = otherProperty;
            Criteria = criteria;

        }

        /// <summary>
        /// Determines whether the specified value of the object is valid.  For this to be the case, the objects must be of the same type
        /// and satisfy the comparison criteria. Null values will return false in all cases except when both
        /// objects are null.  The objects will need to implement IComparable for the GreaterThan,LessThan,GreatThanOrEqualTo and LessThanOrEqualTo instances
        /// </summary>
        /// <param name="value">The value of the object to validate</param>
        /// <param name="validationContext">The validation context</param>
        /// <returns>A validation result if the object is invalid, null if the object is valid</returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            // the the other property
            var property = validationContext.ObjectType.GetProperty(OtherProperty);
            string compareChar = "";
            // check it is not null
            if (property == null)
                return new ValidationResult(String.Format("Unknown property: {0}.", OtherProperty));

            // check types
            var memberName = validationContext.ObjectType.GetProperties().Where(p => p.GetCustomAttributes(false).OfType<DisplayAttribute>().Any(a => a.Name == validationContext.DisplayName)).Select(p => p.Name).FirstOrDefault();
            if (memberName == null)
            {
                memberName = validationContext.DisplayName;
            }
            if (validationContext.ObjectType.GetProperty(memberName).PropertyType != property.PropertyType)
                return new ValidationResult(String.Format("The types of {0} and {1} must be the same.", memberName, OtherProperty));

            // get the other value
            var other = property.GetValue(validationContext.ObjectInstance, null);

            // equals to comparison,
            if (Criteria == CompareValues.EqualTo)
            {
                if (Object.Equals(value, other))
                    return null;
            }
            else if (Criteria == CompareValues.NotEqualTo)
            {
                if (!Object.Equals(value, other))
                    return null;
            }
            else
            {
                // check that both objects are IComparables
                if (!(value is IComparable) || !(other is IComparable))
                    return new ValidationResult(String.Format("{0} and {1} must both implement IComparable", validationContext.DisplayName, OtherProperty));

                // compare the objects
                var result = Comparer.Default.Compare(value, other);

                switch (Criteria)
                {
                    case CompareValues.GreaterThan:
                        compareChar = "大于";
                        if (result > 0)
                            return null;
                        break;
                    case CompareValues.LessThan:
                        compareChar = "小于";
                        if (result < 0)
                            return null;
                        break;
                    case CompareValues.GreatThanOrEqualTo:
                        compareChar = "大于等于";
                        if (result >= 0)
                            return null;
                        break;
                    case CompareValues.LessThanOrEqualTo:
                        compareChar = "小于等于";
                        if (result <= 0)
                            return null;
                        break;
                }
            }
            ErrorMessage = string.Format("{0} 必须{1}{2}", validationContext.DisplayName, compareChar, OtherProperty);
            // got this far must mean the items don‘t meet the comparison criteria
            return new ValidationResult(ErrorMessage);
        }
    }

    /// <summary>
    /// Indicates a comparison criteria used by the CompareValues attribute
    /// </summary>
    public enum CompareValues
    {
        EqualTo,
        NotEqualTo,
        GreaterThan,
        LessThan,
        GreatThanOrEqualTo,
        LessThanOrEqualTo
    }
    #endregion 对两个属性值的大小进行验证


    public class DecimalTwoPlacesAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult($"字段: {validationContext.DisplayName} 只能有两位小数.");
            }

            var valueAsString = value.ToString();
            if (!Regex.IsMatch(valueAsString, @"^\d+(\.\d{1,2})?$"))
            {
                return new ValidationResult($"字段: {validationContext.DisplayName} 只能有两位小数.");
            }

            return ValidationResult.Success;
        }
    }
}




