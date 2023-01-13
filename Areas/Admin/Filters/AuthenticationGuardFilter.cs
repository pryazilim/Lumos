using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class AuthenticationGuardAttribute : ActionFilterAttribute
{
  public override void OnActionExecuting(ActionExecutingContext filterContext)
  {
    if (string.IsNullOrWhiteSpace(filterContext.HttpContext.Session.GetString("CurrentUser")))
    {
      filterContext.Result = new RedirectToRouteResult(routeName: "AdminLogin", permanent: false, routeValues: null);
    }
  }
}
