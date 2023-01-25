using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Lumos.Base
{
  public class Enum
  {
    public enum LayoutInfo
    {
      Logo = 1,
      Address = 2,
      Phone = 3,
      Fax = 4,
      FacebookLink = 5,
      InstagramLink = 6,
      LinkedinLink = 7,
      YoutubeLink = 8,
      TwitterLink = 9,
      GoogleLink = 10,
      Map = 11,
      Email = 12,
      MessageEmail = 13,
      OrderEmail = 14,
      Description = 15,
      Keywords = 16,
      Meta = 17,
      Google = 18,
      Zendesk = 19,
      Whatsapp = 20,
      Phone2 = 21,
      EMagaza = 22,
      ContactTitle = 23,
      ContactDesc = 24,
    }

    public enum LanguageEnum
    {
      Turkce = 1,
      English = 2,
      Deustch = 3,
      Rusca = 4
    }
    public enum AboutEnum
    {
      Corporate = 1,
    }

    public enum SeoPage
    {
      Seo1 = 1,
      Seo2 = 2,
      Seo3 = 3,
      Seo4 = 4,
      Seo5 = 5,
      Seo6 = 6,
      Seo7 = 7,
      Seo8 = 8,
      Seo9 = 9,
      Seo10 = 10,
      Seo11 = 11,
      Seo12 = 12,
      Seo13 = 13,
      Seo14 = 14,
      Seo15 = 15,
    }


    public enum CategoryEnum
    {
      [Description("Tamamlanan Projeler")]
      Tamamlanan = 1,
      [Description("Güncel Projeler")]
      Guncel = 2,
      [Description("Başlayacak Projeler")]
      Baslayacak = 3
    }
    public enum ProjectGalleryEnum
    {
      Gallery = 1,
      Profil = 2,
      Combination = 3
    }
    public enum RandevuEnum
    {
      [Description("Onay Bekliyor")]
      OnayBekliyor = 1,
      [Description("Onaylandı")]
      Onaylandi = 2,
      [Description("Onaylanmadı")]
      Onaylanmadi = 3,
      [Description("Silindi")]
      Silindi = 4
    }

  }
}
