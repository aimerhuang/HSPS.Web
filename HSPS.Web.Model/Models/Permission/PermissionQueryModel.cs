using System.ComponentModel.DataAnnotations;

namespace HSPS.Web.Model.Models;

public class PermissionQueryModel
{

    public string Code { get; set; }
    public string Name { get; set; }
    public int? StartPage { get; set; }


    public int? PageSize { get; set; }

}
