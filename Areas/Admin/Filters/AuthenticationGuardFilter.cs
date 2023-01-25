using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class AuthenticationGuardAttribute : ActionFilterAttribute
{
  public string Page { get; set; }
  public override void OnActionExecuting(ActionExecutingContext filterContext)
  {
    string action = Page!;

    if (string.IsNullOrWhiteSpace(filterContext.HttpContext.Session.GetString("CurrentUser")))
    {
      filterContext.Result = new RedirectToActionResult("Login", "", null);
    }
    else
    {
      string currentUser;

      var currentUserValue = filterContext.HttpContext.Session.GetString("CurrentUser");

      var currentUserId = Convert.ToInt32(currentUserValue);

      using (var db = new DataContext())
      {
        currentUser = db.AdminUser!.Where(x => x.Id == currentUserId).Select(x => x.Permission).FirstOrDefault();
      }

      var permissionList =  JsonConvert.DeserializeObject<List<string>>(currentUser!);

      if (currentUser == null)
      {
        filterContext.Result = new RedirectToActionResult("Login", "", null);
      }

      if(!permissionList!.Any(x => x == action))
      {
        if (permissionList!.Any(x => x == "Index"))
        {
          filterContext.Result = new RedirectResult("/admin");
        }
        else
        {
          filterContext.Result = new RedirectToActionResult("Login", "", null);
        }
      }
    }
  }
}
