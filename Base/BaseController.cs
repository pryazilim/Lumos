using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Azure.Core;
using System.Web;
using Lumos.Base;

namespace Lumos.Base
{
  public class BaseController : Controller
  {

    protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
    {
      try
      {
        // var userLanguages = Request.UserLanguages;
        var routes = RouteTable.Routes;
        // TODO:SOru-2
        var routeData = Request.Url.AbsolutePath;
        CultureInfo cultureInfo = null;
        var language = "";

        if (routeData.Length < 3)
          language = "";
        else if (routeData.Length == 3)
          language = routeData[1].ToString() + routeData[2].ToString();
        else if (routeData.Length > 3 && routeData[3] == '/')
          language = routeData[1].ToString() + routeData[2].ToString();
        else
          language = "";


        try
        {
          if (language == "tr" || language == "en")
          {
            Functions.SetLangCookie(language);
            cultureInfo = new CultureInfo(language);
          }
          else
          {
            //var langc = Functions.GetLangCookie();
            //if (!string.IsNullOrWhiteSpace(langc))
            //{
            //    cultureInfo = new CultureInfo(langc);

            //}
            //else
            //{
            //    if (userLanguages.Count() > 0)
            //    {
            //        try
            //        {
            //            var userLanguage = userLanguages[0][0].ToString() + userLanguages[0][1].ToString();
            //            if (userLanguage == "tr" || userLanguage == "en" /*|| userLanguage == "de")
            //            {
            //                Functions.SetLangCookie(userLanguage);
            //                cultureInfo = new CultureInfo(userLanguage);
            //            }
            //            else
            //            {
            //                Functions.SetLangCookie("tr");
            //                cultureInfo = new CultureInfo("tr");
            //            }
            //        }
            //        catch (CultureNotFoundException)
            //        {
            //            Functions.SetLangCookie("tr");
            //            cultureInfo = new CultureInfo("tr");
            //        }
            //    }
            //    else
            //    {
            Functions.SetLangCookie("tr");
            cultureInfo = new CultureInfo("tr");
            //        }
            //    }

            //}
          }
        }
        catch (Exception)
        {
          Functions.SetLangCookie("tr");
          cultureInfo = new CultureInfo("tr");
        }

        System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo;
        System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfo;
      }
      catch
      {

      }

      return base.BeginExecuteCore(callback, state);
    }
    protected override void OnActionExecuting(ActionExecutingContext filterContext)
    {
      ViewBag.UserLanguage = System.Threading.Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName;
      base.OnActionExecuting(filterContext);
    }
  }
}
