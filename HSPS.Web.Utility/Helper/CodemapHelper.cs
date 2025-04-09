

using HSPS.Web.IServices.wcf;

namespace HSPS.Web.Utility.Helper
{
    public class CodemapHelper
    {
        private static ICodeMapServices _codeMapServices;

        public CodemapHelper(ICodeMapServices codeMapServices)
        {
            _codeMapServices= codeMapServices;

        }
        /// <summary>
        /// 根据code取名称
        /// </summary>
        /// <param name="classTypes"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public string GetNameByCode(string classTypes, string code)
        {
            var classTypeList = classTypes.Split(',');

            var list= _codeMapServices.GetCodeMapByType(classTypes);
            //object cacheObj = CodemapServices.GetCodeMapByType(classTypes);//CacheHelper.GetCache(Constant.CACHE_HSPS_CODEMAP);
            //IEnumerable<CodeMap> allCodeMap = null;
            //if (cacheObj == null)
            //{
            //    return code;
            //}
            //allCodeMap = cacheObj as List<CodeMap>;

            var codemap = list.FirstOrDefault(s => classTypeList.Contains(s.ClassType) && s.Code == code);

            if (codemap == null) return code;

            return codemap.Item;
        }
    }
}
