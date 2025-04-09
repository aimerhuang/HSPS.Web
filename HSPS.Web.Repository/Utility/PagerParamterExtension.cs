using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yiban.SHMedicalRecord.Common.Services;
using YiBan.HSPS.Main.Models.Common;
using YiBan.HSPS.Main.Framework.Extension;

namespace YiBan.HSPS.Main.DAL.Utility
{
    /// <summary>
    /// 
    /// </summary>
    public static class PagerParamterExtension
    {
        public static PagerParameter<TRequst> ToParameter<TRequst>(this EasyUIPager @this)
        {
            var pagerParam = new PagerParameter<TRequst>()
            {
                Parameter = @this.MapTo<TRequst>(),
                PageIndex = @this.PageIndex,
                PageSize = @this.PageSize
            };

            return pagerParam;
        }

        public static PagerParameter ToParameter(this EasyUIPager @this)
        {
            var pagerParam = new PagerParameter()
            {
                PageIndex = @this.PageIndex,
                PageSize = @this.PageSize
            };

            return pagerParam;
        }
    }
}
