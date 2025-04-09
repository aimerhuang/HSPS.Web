namespace HSPS.Web.IServices;

public interface ICodeMapServices
{
    IEnumerable<Model.Models.Extensions.CodeMap> GetCodeMapByType(string classType);
}
