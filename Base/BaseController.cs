using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Lumos.Base
{
  public class BaseController : Controller
  {
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
      var languageCode = HttpContext.GetRouteData().Values["languageCode"].ToString();

      CultureInfo cultureInfo = null;

      try
      {
        if (languageCode != "tr" && languageCode != "en")
        {
          languageCode = Request.GetTypedHeaders()
                                .AcceptLanguage
                                ?.OrderByDescending(x => x.Quality ?? 1)
                                .Where(e => e.Value.ToString() == "tr" || e.Value.ToString() == "en")
                                .Select(x => x.Value.ToString())
                                .FirstOrDefault() ?? "tr";
        }
      }
      catch (Exception)
      {
        languageCode = "tr";
      }

      Functions.SetLangCookie(HttpContext, languageCode);

      cultureInfo = new CultureInfo(languageCode);

      Thread.CurrentThread.CurrentCulture = cultureInfo;
      Thread.CurrentThread.CurrentUICulture = cultureInfo;

      ViewBag.UserLanguage = Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName;

      base.OnActionExecuting(filterContext);
    }
  }
}
