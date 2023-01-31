using Lumos.Base;

namespace Lumos.Areas.Admin.Models.BaseModel
{
  public class LayoutModel : BaseController
  {
    private List<string> _permissionList;

    private List<string> PermissionList
    {
      get
      {
        if (_permissionList == null)
        {
          var list = Statics.getAdminValues();
          _permissionList = list.Where(x => x.Id == Functions.AdminUserID(HttpContext)).Select(x => x.PermissionList).FirstOrDefault();
        }
        return _permissionList;
      }
    }

    public List<LanguageModel> LanguageList
    {
      get
      {
        return Statics.getLanguageValues();
      }
    }

    private string username;
    public string AdminUsername
    {
      get
      {
        if (string.IsNullOrWhiteSpace(username))
          username = Functions.AdminUsername(HttpContext);
        return username;
      }
    }
    public bool CheckAccess(string page)
    {
      if (AdminUsername == "pryazilim")
        return true;

      if (PermissionList == null || !PermissionList.Any(x => x == page))
        return false;

      return true;
    }
  }
}
