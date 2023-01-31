using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Lumos.Base.Enum;

namespace Lumos.Base
{
  public static class Statics
  {
    private static List<AdminUser> _AdmindbData;
    private static List<Layout> _LayoutdbData;
    private static List<Language> _LanguagedbData;
    private static List<Seo> _SeodbData;
    private static List<SeoLanguage> _SeoLanguagedbData;

    //private static List<CategoryProduct> _CategoryProductdbData;
    //private static List<CategoryProductLanguage> _CategoryProductLanguagedbData;


    //private static List<Models.Site.GeneralModels.CategoryProductModel> _CategoryProductInfoValues;

    private static List<Areas.Admin.Models.GeneralModels.AdminModel> _AdminInfoValues;
    private static Models.GeneralModels.LayoutDataModel _LayoutInfoValues;
    private static List<Areas.Admin.Models.BaseModel.LanguageModel> _LanguageInfoValues;
    private static Models.GeneralModels.SeoModel _SeoInfoValues;

    public static List<Layout> LayoutdbData
    {
      get
      {
        if (_LayoutdbData == null)
        {
          var db = new DataContext();

          _LayoutdbData = db.Layout!.ToList();
        }
        return _LayoutdbData;
      }

    }

    public static List<AdminUser> AdmindbData
    {
      get
      {
        if (_AdmindbData == null)
        {
          var db = new DataContext();

          _AdmindbData = db.AdminUser!.ToList();
        }
        return _AdmindbData;
      }
    }
    public static List<Language> LanguagedbData
    {
      get
      {
        if (_LanguagedbData == null)
        {
          var db = new DataContext();

          _LanguagedbData = db.Language.ToList();
        }
        return _LanguagedbData;
      }
    }
    public static List<Seo> SeodbData
    {
      get
      {
        if (_SeodbData == null)
        {
          var db = new DataContext();

          _SeodbData = db.Seo!.ToList();
        }
        return _SeodbData;
      }
    }
    public static List<SeoLanguage> SeoLanguagedbData
    {
      get
      {
        if (_SeoLanguagedbData == null)
        {
          var db = new DataContext();

          _SeoLanguagedbData = db.SeoLanguage!.ToList();
        }
        return _SeoLanguagedbData;
      }
    }


    public static void ResetLayoutData()
    {
      _LayoutdbData = null;
      _LayoutInfoValues = null;
    }
    public static void ResetAdminData()
    {
      _AdmindbData = null;
      _AdminInfoValues = null;
    }
    public static void ResetSeoData()
    {
      _SeodbData = null;
      _SeoLanguagedbData = null;
      _SeoInfoValues = null;
    }
    //public static void ResetCategoryProductData()
    //{
    //  _CategoryProductdbData = null;
    //  _CategoryProductLanguagedbData = null;
    //  _CategoryProductInfoValues = null;
    //}


    public static Models.GeneralModels.LayoutDataModel getLayoutValues()
    {
      if (_LayoutInfoValues == null)
      {
        var data = LayoutdbData;

        var _LayoutDetail = new Models.GeneralModels.LayoutDataModel();

        _LayoutDetail.Address = data.Where(x => x.Type == (byte)LayoutInfo.Address).Select(x => new Models.GeneralModels.LayoutDataDetailModel
        {
          Id = x.Id,
          Text = x.ContentText,
        }).FirstOrDefault();

        _LayoutDetail.Phone = data.Where(x => x.Type == (byte)LayoutInfo.Phone).Select(x => new Models.GeneralModels.LayoutDataDetailModel
        {
          Id = x.Id,
          Text = x.ContentText,
        }).FirstOrDefault();

        _LayoutDetail.Fax = data.Where(x => x.Type == (byte)LayoutInfo.Fax).Select(x => new Models.GeneralModels.LayoutDataDetailModel
        {
          Id = x.Id,
          Text = x.ContentText,
        }).FirstOrDefault();

        _LayoutDetail.FacebookLink = data.Where(x => x.Type == (byte)LayoutInfo.FacebookLink).Select(x => new Models.GeneralModels.LayoutDataDetailModel
        {
          Id = x.Id,
          Text = x.ContentText,
        }).FirstOrDefault();

        _LayoutDetail.InstagramLink = data.Where(x => x.Type == (byte)LayoutInfo.InstagramLink).Select(x => new Models.GeneralModels.LayoutDataDetailModel
        {
          Id = x.Id,
          Text = x.ContentText,
        }).FirstOrDefault();

        _LayoutDetail.LinkedinLink = data.Where(x => x.Type == (byte)LayoutInfo.LinkedinLink).Select(x => new Models.GeneralModels.LayoutDataDetailModel
        {
          Id = x.Id,
          Text = x.ContentText,
        }).FirstOrDefault();

        _LayoutDetail.Phone2 = data.Where(x => x.Type == (byte)LayoutInfo.Phone2).Select(x => new Models.GeneralModels.LayoutDataDetailModel
        {
          Id = x.Id,
          Text = x.ContentText,
        }).FirstOrDefault();

        _LayoutDetail.YoutubeLink = data.Where(x => x.Type == (byte)LayoutInfo.YoutubeLink).Select(x => new Models.GeneralModels.LayoutDataDetailModel
        {
          Id = x.Id,
          Text = x.ContentText,
        }).FirstOrDefault();

        _LayoutDetail.TwitterLink = data.Where(x => x.Type == (byte)LayoutInfo.TwitterLink).Select(x => new Models.GeneralModels.LayoutDataDetailModel
        {
          Id = x.Id,
          Text = x.ContentText,
        }).FirstOrDefault();

        _LayoutDetail.GoogleLink = data.Where(x => x.Type == (byte)LayoutInfo.GoogleLink).Select(x => new Models.GeneralModels.LayoutDataDetailModel
        {
          Id = x.Id,
          Text = x.ContentText,
        }).FirstOrDefault();

        _LayoutDetail.Map = data.Where(x => x.Type == (byte)LayoutInfo.Map).Select(x => new Models.GeneralModels.LayoutDataDetailModel
        {
          Id = x.Id,
          Text = x.ContentText,
        }).FirstOrDefault();

        _LayoutDetail.Email = data.Where(x => x.Type == (byte)LayoutInfo.Email).Select(x => new Models.GeneralModels.LayoutDataDetailModel
        {
          Id = x.Id,
          Text = x.ContentText,
        }).FirstOrDefault();

        _LayoutDetail.MessageEmail = data.Where(x => x.Type == (byte)LayoutInfo.MessageEmail).Select(x => new Models.GeneralModels.LayoutDataDetailModel
        {
          Id = x.Id,
          Text = x.ContentText,
        }).FirstOrDefault();

        _LayoutDetail.OrderEmail = data.Where(x => x.Type == (byte)LayoutInfo.OrderEmail).Select(x => new Models.GeneralModels.LayoutDataDetailModel
        {
          Id = x.Id,
          Text = x.ContentText,
        }).FirstOrDefault();

        _LayoutDetail.Description = data.Where(x => x.Type == (byte)LayoutInfo.Description).Select(x => new Models.GeneralModels.LayoutDataDetailModel
        {
          Id = x.Id,
          Text = x.ContentText,
        }).FirstOrDefault();

        _LayoutDetail.Keywords = data.Where(x => x.Type == (byte)LayoutInfo.Keywords).Select(x => new Models.GeneralModels.LayoutDataDetailModel
        {
          Id = x.Id,
          Text = x.ContentText,
        }).FirstOrDefault();

        _LayoutDetail.Meta = data.Where(x => x.Type == (byte)LayoutInfo.Meta).Select(x => new Models.GeneralModels.LayoutDataDetailModel
        {
          Id = x.Id,
          Text = x.ContentText,
        }).FirstOrDefault();

        _LayoutDetail.Google = data.Where(x => x.Type == (byte)LayoutInfo.Google).Select(x => new Models.GeneralModels.LayoutDataDetailModel
        {
          Id = x.Id,
          Text = x.ContentText,
        }).FirstOrDefault();

        _LayoutDetail.Zendesk = data.Where(x => x.Type == (byte)LayoutInfo.Zendesk).Select(x => new Models.GeneralModels.LayoutDataDetailModel
        {
          Id = x.Id,
          Text = x.ContentText,
        }).FirstOrDefault();

        _LayoutDetail.Whatsapp = data.Where(x => x.Type == (byte)LayoutInfo.Whatsapp).Select(x => new Models.GeneralModels.LayoutDataDetailModel
        {
          Id = x.Id,
          Text = x.ContentText,
        }).FirstOrDefault();

        _LayoutDetail.ContactTitle = data.Where(x => x.Type == (byte)LayoutInfo.ContactTitle).Select(x => new Models.GeneralModels.LayoutDataDetailModel
        {
          Id = x.Id,
          Text = x.ContentText,
        }).FirstOrDefault();

        _LayoutDetail.ContactDesc = data.Where(x => x.Type == (byte)LayoutInfo.ContactDesc).Select(x => new Models.GeneralModels.LayoutDataDetailModel
        {
          Id = x.Id,
          Text = x.ContentText,
        }).FirstOrDefault();




        _LayoutInfoValues = _LayoutDetail;

      }
      return _LayoutInfoValues;
    }

    public static List<Areas.Site.Models.GeneralModels.ServicesModel> getAboutValues(int _langid)
    {
      var _values = new List<Areas.Site.Models.GeneralModels.ServicesModel>();
      using (var db = new DataContext())
      {
        var _Category = db.About!.ToList();
        var _CategoryLang = db.AboutLanguage!.Where(x => x.LanguageId == _langid).ToList();
        _values = (from s in _Category
                   select new Areas.Site.Models.GeneralModels.ServicesModel
                   {
                     Id = s.Id,
                     Type = s.Type,
                     CreatedDate = s.CreatedDate,
                     PhotoPath2 = s.PhotoPath2,
                     IsFeatured = s.IsFeatured,
                     PhotoPath = s.PhotoPath,
                     UpdateDate = s.UpdatedDate,
                     OrderBy = s.OrderBy,
                     ServicesLanguageList = (from s1 in _CategoryLang
                                             where s1.AboutId == s.Id
                                             select new Areas.Site.Models.GeneralModels.ServicesInnerModel
                                             {
                                               Id = s1.Id,
                                               Title = s1.Title,
                                               Description = s1.Description,
                                               LanguageId = s1.LanguageId,
                                             }).FirstOrDefault() ?? new Areas.Site.Models.GeneralModels.ServicesInnerModel()
                   }).OrderBy(x => x.OrderBy).ToList() ?? new List<Areas.Site.Models.GeneralModels.ServicesModel>();
      }
      return _values;
    }
    public static List<Areas.Admin.Models.GeneralModels.AdminModel> getAdminValues()
    {
      if (_AdminInfoValues == null)
      {
        var data = AdmindbData;

        _AdminInfoValues = (from a in data
                            select new Areas.Admin.Models.GeneralModels.AdminModel
                            {
                              Id = a.Id,
                              Name = a.Password,
                              Password = a.Password,
                              CreatedDate = a.CreatedDate,
                              Permission = a.Permission ?? "-",
                            }).ToList();

        _AdminInfoValues.Add(new Areas.Admin.Models.GeneralModels.AdminModel
        {
          CreatedDate = DateTime.Now.AddYears(-1),
          Name = "pryazilim",
          Password = "7ugur7",
          Id = 777777
        });
      }

      return _AdminInfoValues;
    }
    public static List<Areas.Admin.Models.BaseModel.LanguageModel> getLanguageValues()
    {
      if (_LanguageInfoValues == null)
      {
        var data = LanguagedbData;

        _LanguageInfoValues = (from a in data
                               select new Areas.Admin.Models.BaseModel.LanguageModel
                               {
                                 LanguageID = a.LanguageID,
                                 DisplayName = a.DisplayName,
                                 VariableCode = a.VariableCode,
                                 LanguageName = a.LanguageName
                               }).ToList();
      }

      return _LanguageInfoValues;
    }
    public static Models.GeneralModels.SeoModel getSeoValues()
    {
      if (_SeoInfoValues == null)
      {

        var data = SeodbData;
        var datalang = SeoLanguagedbData;
        var _SeoDetail = new Models.GeneralModels.SeoModel();

        _SeoDetail.Seo1 = data.Where(x => x.Type == (byte)SeoPage.Seo1).Select(x => new Models.GeneralModels.SeoDataModel
        {
          Id = x.Id,
          Type = x.Type,
          SeoLanguageList = (from d in datalang
                             where d.SeoId == x.Id
                             select new Models.GeneralModels.SeoInnerModel
                             {
                               Id = d.Id,
                               Description = d.Description,
                               Keywords = d.Keywords,
                               Title = d.Title,
                               LanguageId = d.LanguageId,
                             }).ToList()
        }).FirstOrDefault();

        _SeoDetail.Seo2 = data.Where(x => x.Type == (byte)SeoPage.Seo2).Select(x => new Models.GeneralModels.SeoDataModel
        {
          Id = x.Id,
          Type = x.Type,
          SeoLanguageList = (from d in datalang
                             where d.SeoId == x.Id
                             select new Models.GeneralModels.SeoInnerModel
                             {
                               Id = d.Id,
                               Description = d.Description,
                               Keywords = d.Keywords,
                               Title = d.Title,
                               LanguageId = d.LanguageId,
                             }).ToList()
        }).FirstOrDefault();

        _SeoDetail.Seo3 = data.Where(x => x.Type == (byte)SeoPage.Seo3).Select(x => new Models.GeneralModels.SeoDataModel
        {
          Id = x.Id,
          Type = x.Type,
          SeoLanguageList = (from d in datalang
                             where d.SeoId == x.Id
                             select new Models.GeneralModels.SeoInnerModel
                             {
                               Id = d.Id,
                               Description = d.Description,
                               Keywords = d.Keywords,
                               Title = d.Title,
                               LanguageId = d.LanguageId,
                             }).ToList()
        }).FirstOrDefault();

        _SeoDetail.Seo4 = data.Where(x => x.Type == (byte)SeoPage.Seo4).Select(x => new Models.GeneralModels.SeoDataModel
        {
          Id = x.Id,
          Type = x.Type,
          SeoLanguageList = (from d in datalang
                             where d.SeoId == x.Id
                             select new Models.GeneralModels.SeoInnerModel
                             {
                               Id = d.Id,
                               Description = d.Description,
                               Keywords = d.Keywords,
                               Title = d.Title,
                               LanguageId = d.LanguageId,
                             }).ToList()
        }).FirstOrDefault();

        _SeoDetail.Seo5 = data.Where(x => x.Type == (byte)SeoPage.Seo5).Select(x => new Models.GeneralModels.SeoDataModel
        {
          Id = x.Id,
          Type = x.Type,
          SeoLanguageList = (from d in datalang
                             where d.SeoId == x.Id
                             select new Models.GeneralModels.SeoInnerModel
                             {
                               Id = d.Id,
                               Description = d.Description,
                               Keywords = d.Keywords,
                               Title = d.Title,
                               LanguageId = d.LanguageId,
                             }).ToList()
        }).FirstOrDefault();

        _SeoDetail.Seo6 = data.Where(x => x.Type == (byte)SeoPage.Seo6).Select(x => new Models.GeneralModels.SeoDataModel
        {
          Id = x.Id,
          Type = x.Type,
          SeoLanguageList = (from d in datalang
                             where d.SeoId == x.Id
                             select new Models.GeneralModels.SeoInnerModel
                             {
                               Id = d.Id,
                               Description = d.Description,
                               Keywords = d.Keywords,
                               Title = d.Title,
                               LanguageId = d.LanguageId,
                             }).ToList()
        }).FirstOrDefault();

        _SeoDetail.Seo7 = data.Where(x => x.Type == (byte)SeoPage.Seo7).Select(x => new Models.GeneralModels.SeoDataModel
        {
          Id = x.Id,
          Type = x.Type,
          SeoLanguageList = (from d in datalang
                             where d.SeoId == x.Id
                             select new Models.GeneralModels.SeoInnerModel
                             {
                               Id = d.Id,
                               Description = d.Description,
                               Keywords = d.Keywords,
                               Title = d.Title,
                               LanguageId = d.LanguageId,
                             }).ToList()
        }).FirstOrDefault();

        _SeoDetail.Seo8 = data.Where(x => x.Type == (byte)SeoPage.Seo8).Select(x => new Models.GeneralModels.SeoDataModel
        {
          Id = x.Id,
          Type = x.Type,
          SeoLanguageList = (from d in datalang
                             where d.SeoId == x.Id
                             select new Models.GeneralModels.SeoInnerModel
                             {
                               Id = d.Id,
                               Description = d.Description,
                               Keywords = d.Keywords,
                               Title = d.Title,
                               LanguageId = d.LanguageId,
                             }).ToList()
        }).FirstOrDefault();

        _SeoDetail.Seo9 = data.Where(x => x.Type == (byte)SeoPage.Seo9).Select(x => new Models.GeneralModels.SeoDataModel
        {
          Id = x.Id,
          Type = x.Type,
          SeoLanguageList = (from d in datalang
                             where d.SeoId == x.Id
                             select new Models.GeneralModels.SeoInnerModel
                             {
                               Id = d.Id,
                               Description = d.Description,
                               Keywords = d.Keywords,
                               Title = d.Title,
                               LanguageId = d.LanguageId,
                             }).ToList()
        }).FirstOrDefault();

        _SeoDetail.Seo10 = data.Where(x => x.Type == (byte)SeoPage.Seo10).Select(x => new Models.GeneralModels.SeoDataModel
        {
          Id = x.Id,
          Type = x.Type,
          SeoLanguageList = (from d in datalang
                             where d.SeoId == x.Id
                             select new Models.GeneralModels.SeoInnerModel
                             {
                               Id = d.Id,
                               Description = d.Description,
                               Keywords = d.Keywords,
                               Title = d.Title,
                               LanguageId = d.LanguageId,
                             }).ToList()
        }).FirstOrDefault();

        _SeoDetail.Seo11 = data.Where(x => x.Type == (byte)SeoPage.Seo11).Select(x => new Models.GeneralModels.SeoDataModel
        {
          Id = x.Id,
          Type = x.Type,
          SeoLanguageList = (from d in datalang
                             where d.SeoId == x.Id
                             select new Models.GeneralModels.SeoInnerModel
                             {
                               Id = d.Id,
                               Description = d.Description,
                               Keywords = d.Keywords,
                               Title = d.Title,
                               LanguageId = d.LanguageId,
                             }).ToList()
        }).FirstOrDefault();

        _SeoDetail.Seo12 = data.Where(x => x.Type == (byte)SeoPage.Seo12).Select(x => new Models.GeneralModels.SeoDataModel
        {
          Id = x.Id,
          Type = x.Type,
          SeoLanguageList = (from d in datalang
                             where d.SeoId == x.Id
                             select new Models.GeneralModels.SeoInnerModel
                             {
                               Id = d.Id,
                               Description = d.Description,
                               Keywords = d.Keywords,
                               Title = d.Title,
                               LanguageId = d.LanguageId,
                             }).ToList()
        }).FirstOrDefault();

        _SeoDetail.Seo13 = data.Where(x => x.Type == (byte)SeoPage.Seo13).Select(x => new Models.GeneralModels.SeoDataModel
        {
          Id = x.Id,
          Type = x.Type,
          SeoLanguageList = (from d in datalang
                             where d.SeoId == x.Id
                             select new Models.GeneralModels.SeoInnerModel
                             {
                               Id = d.Id,
                               Description = d.Description,
                               Keywords = d.Keywords,
                               Title = d.Title,
                               LanguageId = d.LanguageId,
                             }).ToList()
        }).FirstOrDefault();

        _SeoDetail.Seo14 = data.Where(x => x.Type == (byte)SeoPage.Seo14).Select(x => new Models.GeneralModels.SeoDataModel
        {
          Id = x.Id,
          Type = x.Type,
          SeoLanguageList = (from d in datalang
                             where d.SeoId == x.Id
                             select new Models.GeneralModels.SeoInnerModel
                             {
                               Id = d.Id,
                               Description = d.Description,
                               Keywords = d.Keywords,
                               Title = d.Title,
                               LanguageId = d.LanguageId,
                             }).ToList()
        }).FirstOrDefault();

        _SeoDetail.Seo15 = data.Where(x => x.Type == (byte)SeoPage.Seo15).Select(x => new Models.GeneralModels.SeoDataModel
        {
          Id = x.Id,
          Type = x.Type,
          SeoLanguageList = (from d in datalang
                             where d.SeoId == x.Id
                             select new Models.GeneralModels.SeoInnerModel
                             {
                               Id = d.Id,
                               Description = d.Description,
                               Keywords = d.Keywords,
                               Title = d.Title,
                               LanguageId = d.LanguageId,
                             }).ToList()
        }).FirstOrDefault();

        _SeoInfoValues = _SeoDetail;
      }

      return _SeoInfoValues;

    }

    public static List<Areas.Site.Models.GeneralModels.AddressModel> GetAddressValues(int _langid)
    {
      var _values = new List<Areas.Site.Models.GeneralModels.AddressModel>();
      using (var db = new DataContext())
      {
        var _Address = db.Address!.ToList();
        var _AddressLang = db.AddressLanguage!.Where(x => x.LanguageId == _langid).ToList();
        _values = (from s in _Address
                   select new Areas.Site.Models.GeneralModels.AddressModel
                   {
                     Id = s.Id,
                     OrderBy = s.OrderBy,
                     Address = s.Address1,
                     CreatedDate = s.CreatedDate,
                     UpdateDate =s.UpdatedDate,
                     AddresLanguageList = (from s1 in _AddressLang
                                           where s1.AddressId == s.Id
                                           select new Areas.Site.Models.GeneralModels.AddressInnerModel
                                           {
                                             Title = s1.Title,
                                             Phone = s1.Phone,
                                             Mail = s1.Mail,
                                             Map = s1.Map,
                                             Fax = s1.Fax,
                                           }).FirstOrDefault() ?? new Areas.Site.Models.GeneralModels.AddressInnerModel()
                   }).ToList() ?? new List<Areas.Site.Models.GeneralModels.AddressModel>();
      }
      return _values;
    }
  }
}
