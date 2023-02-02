using Lumos.Base;
using Lumos;
using Microsoft.AspNetCore.Http.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Http;
using Azure.Core;

namespace Lumos.Areas.Site.Models.BaseModel
{
  public class LayoutModel
  {
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LayoutModel(IHttpContextAccessor httpContextAccessor)
    {
      _httpContextAccessor = httpContextAccessor;
    }
    public string Url { get; set; }
    public string GetTrUrl
    {
      get
      {
        var httpContext = _httpContextAccessor.HttpContext;
        var url = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}{httpContext.Request.Path}{httpContext.Request.QueryString}";

        if (url.Length < 3)
        {
          url = "/tr/";
        }
        else if (url.Length == 3)
        {
          url = url.Replace("/en", "/tr");
        }
        else if (url.Length > 3 && url[3] == '/')
        {
          url = url.Replace("/en/", "/tr/");
        }
        else
        {
          url = "/tr" + url;
        }
        return url;
      }
    }

    public string GetEnUrl
    {
      get
      {
        var httpContext = _httpContextAccessor.HttpContext;
        var url = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}{httpContext.Request.Path}{httpContext.Request.QueryString}";

        if (Url.Length < 3)
          Url = "/en/";
        else if (Url.Length == 3)
          Url = Url.Replace("/tr", "/en");
        else if (Url.Length > 3 && Url[3] == '/')
          Url = Url.Replace("/tr/", "/en/");
        else
          Url = "/en" + Url;
        return Url;
      }
    }

    //public string GetDeUrl
    //{
    //    get
    //    {
    //        Url = HttpContext.Current.Request.Url.AbsolutePath;

    //        if (Url.Length < 3)
    //            Url = "/de/";
    //        else if (Url.Length == 3)
    //            Url = Url.Replace("/tr", "/de").Replace("/en", "/de");
    //        else if (Url.Length > 3 && Url[3] == '/')
    //            Url = Url.Replace("/tr/", "/de/").Replace("/en/", "/de/");
    //        else
    //            Url = "/de" + Url;
    //        return Url;
    //    }
    //}

    public string GetRndWeather
    {
      get
      {
        Random _temRnd = new Random();
        int _tempVal = _temRnd.Next(20);
        return _tempVal.ToString();
      }
    }

    public string GenerateLink(string link)
    {
      return "/" + Resource.LANG_NAME + "/" + link;
    }

    public Lumos.Models.GeneralModels.LayoutDataModel LayoutInfo
    {
      get
      {
        return Lumos.Base.Statics.getLayoutValues();
      }
    }

    public Lumos.Models.GeneralModels.SeoModel MetaInfo
    {
      get
      {
        return Lumos.Base.Statics.getSeoValues();
      }
    }
  }
}
