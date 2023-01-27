using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lumos.Areas.Admin.Models.GeneralModels
{
  public class AdminModel
  {
    private string _permission = "";
    private List<string> _permissionList = new List<string>();

    public int Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string Permission
    {
      get
      {
        return _permission;
      }
      set
      {
        _permission = value;
        _permissionList = JsonConvert.DeserializeObject<List<string>>(value);
      }
    }
    public List<string> PermissionList
    {
      get { return _permissionList; }
    }
  }
}
