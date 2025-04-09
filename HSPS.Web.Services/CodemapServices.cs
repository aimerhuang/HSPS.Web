
using HSPS.Web.Repository;
using HSPS.Web.IServices;

namespace HSPS.Web.Services;

public class CodemapServices: ICodeMapServices
{
    /// <summary>
    /// 根据字典类型获取字典配置项
    /// </summary>
    /// <param name="classType"></param>
    /// <returns></returns>
    public IEnumerable<Model.Models.Extensions.CodeMap> GetCodeMapByType(string classType)
    {

        IEnumerable<HIPS.HSPS.Interface.Persistence.Web.CodeMap> list = InterfaceObjectHelper.CallMethod<string, IEnumerable<HIPS.HSPS.Interface.Persistence.Web.CodeMap>>(RemotingInterfaceService.MtCodeMapService.GetCodeMaps, classType);
        if (list != null)
        {
            IEnumerable<Model.Models.Extensions.CodeMap> result = list.CastExtension<Model.Models.Extensions.CodeMap>();
            List<Model.Models.Extensions.CodeMap> newList = new List<Model.Models.Extensions.CodeMap>();
            foreach (var item in result)
            {
                if (item.IsEnable)
                {
                    newList.Add(item);
                }
            }
            return newList;
        }
        return null;
    }
}
