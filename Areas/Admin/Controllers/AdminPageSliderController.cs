using Lumos.Areas.Admin.Models.BaseModel;
using Microsoft.AspNetCore.Mvc;
using Lumos.Base;
using System.Drawing;
using System.Net;

namespace Lumos.Admin;

public class AdminPageSliderController : Controller
{
  private readonly IWebHostEnvironment _webHostEnvironment;

  public List<LanguageModel> LanguageList
  {
    get
    {
      return Statics.getLanguageValues();
    }
  }
  private readonly ILogger<AdminPageController> _logger;

  public AdminPageSliderController(ILogger<AdminPageController> logger, IWebHostEnvironment webHostEnvironment)
  {
    _logger = logger;
     _webHostEnvironment= webHostEnvironment;
  }

  [AuthenticationGuard(Page = "Index")]
  public IActionResult Index()
  {
    return View();
  }

  [HttpPost]
  public JsonResult SliderManagement(int id, int Type, int OrderBy, string Title_tr, string Title_en , string UnderTitle_tr, string UnderTitle_en, string ButtonTitle_tr, string ButtonTitle_en, string ButtonUrl_tr, string ButtonUrl_en, IFormFile Logo)
  {


    var result = new Result();

    if (Type != 3 && Logo == null)
    {
      result.Success = false;
      result.Message = "Resim Seçiniz";
      return Json(result);
    }

    if (OrderBy <= 0)
    {
      result.Success = false;
      result.Message = "Görüntülenme sırası giriniz (0 dan büyük bir değer)";
      return Json(result);
    }

    try
    {
      var TitleArray = new List<LanguageModel>();
      var UnderTitleArray = new List<LanguageModel>();
      var ButtonTitleArray = new List<LanguageModel>();
      var ButtonUrlArray = new List<LanguageModel>();


      for (int i = 0; i < LanguageList.Count; i++)
      {
        var variableCode = LanguageList[i].VariableCode;
        var languageId = LanguageList[i].LanguageID;

         if(variableCode == "Tr")
        {
            var Title = Title_tr;
            var _UnderTitle = UnderTitle_tr;
            var _ButtonTitle = ButtonTitle_tr;
            var _ButtonUrl = ButtonUrl_tr;
            string _title = string.Empty;
            if (!string.IsNullOrWhiteSpace(Title))
            {
            _title = WebUtility.HtmlDecode(Title);
            }
          // Here Control data

          TitleArray.Add(new LanguageModel { LanguageID = languageId, Value = _title });
          UnderTitleArray.Add(new LanguageModel { LanguageID = languageId, Value = _UnderTitle });
          ButtonTitleArray.Add(new LanguageModel { LanguageID = languageId, Value = _ButtonTitle });
          ButtonUrlArray.Add(new LanguageModel { LanguageID = languageId, Value = _ButtonUrl });

        }
        else if(variableCode == "En")
        {
            var Title = Title_en;
            var _UnderTitle = UnderTitle_en;
            var _ButtonTitle = ButtonTitle_en;
            var _ButtonUrl = ButtonUrl_en;
            string _title = string.Empty;
            if (!string.IsNullOrWhiteSpace(Title))
            {
            _title = WebUtility.HtmlDecode(Title);
            }
          // Here Control data

          TitleArray.Add(new LanguageModel { LanguageID = languageId, Value = _title });
          UnderTitleArray.Add(new LanguageModel { LanguageID = languageId, Value = _UnderTitle });
          ButtonTitleArray.Add(new LanguageModel { LanguageID = languageId, Value = _ButtonTitle });
          ButtonUrlArray.Add(new LanguageModel { LanguageID = languageId, Value = _ButtonUrl });

        }
      }

      var LogoImgPath = string.Empty;

      if (Logo != null)
      {
        //var _fileName = Logo.FileName.Substring(0, Logo.FileName.LastIndexOf('.'));
        var _fileExtension = Path.GetExtension(Logo.FileName);
        var _fileName = Functions.PhotoTitle(Logo.FileName.Replace(_fileExtension, ""));
        var _fileNameUniq = Functions.GetUniqueKey(5);

        var img = Image.FromStream(Logo.OpenReadStream());

        LogoImgPath = $"{_fileName}_{_fileNameUniq}{_fileExtension}";

        string contentRootPath = _webHostEnvironment.ContentRootPath;

        string path = Path.Combine((@""+contentRootPath+"/UploadFile/Slider"), LogoImgPath);

        Functions.CropImage(img, path, 1920, 1080, false, 4);

        img.Dispose();
        GC.Collect();
      }

      if (id == 0)
      {
        using (var db = new DataContext())
        {

          var nR = new Slider();
          if (!string.IsNullOrWhiteSpace(LogoImgPath))
          {
            nR = new Slider
            {
              CreatedDate = DateTime.Now,
              OrderBy = OrderBy,
              PhotoPath = LogoImgPath,
              Type = Type,

            };
          }
          else
          {
            nR = new Slider
            {
              CreatedDate = DateTime.Now,
              OrderBy = OrderBy,
            };
          }
          db.Slider.Add(nR);
          db.SaveChanges();

          for (int i = 0; i < LanguageList.Count; i++)
          {
            var _nR = new SliderLanguage
            {
              Title = TitleArray.Where(x => x.LanguageID == LanguageList[i].LanguageID).Select(x => x.Value).FirstOrDefault(),
              Description = UnderTitleArray.Where(x => x.LanguageID == LanguageList[i].LanguageID).Select(x => x.Value).FirstOrDefault(),
              ButtonTitle = ButtonTitleArray.Where(x => x.LanguageID == LanguageList[i].LanguageID).Select(x => x.Value).FirstOrDefault(),
              ButtonUrl = ButtonUrlArray.Where(x => x.LanguageID == LanguageList[i].LanguageID).Select(x => x.Value).FirstOrDefault(),
              LanguageId = LanguageList[i].LanguageID,
              SliderId = nR.Id,
            };

            db.SliderLanguage.Add(_nR);
            db.SaveChanges();
          }
          result.Success = true;
        }
      }
      else
      {
        using (var db = new DataContext())
        {
          var data = db.Slider.Where(x => x.Id == id).FirstOrDefault();

          if (data != null)
          {
            var _sliderLanguageList = db.SliderLanguage.Where(x => x.SliderId == id).ToList();

            for (int i = 0; i < LanguageList.Count; i++)
            {
              int _languageID = LanguageList[i].LanguageID ?? 0;

              var SliderLanguage = _sliderLanguageList.Where(y => y.LanguageId == _languageID).FirstOrDefault();

              if (SliderLanguage != null)
              {
                SliderLanguage.Title = TitleArray.Where(x => x.LanguageID == LanguageList[i].LanguageID).Select(x => x.Value).FirstOrDefault();
                SliderLanguage.Description = UnderTitleArray.Where(x => x.LanguageID == LanguageList[i].LanguageID).Select(x => x.Value).FirstOrDefault();
                SliderLanguage.ButtonTitle = ButtonTitleArray.Where(x => x.LanguageID == LanguageList[i].LanguageID).Select(x => x.Value).FirstOrDefault();
                SliderLanguage.ButtonUrl = ButtonUrlArray.Where(x => x.LanguageID == LanguageList[i].LanguageID).Select(x => x.Value).FirstOrDefault();
              }
            }

            data.UpdatedDate = DateTime.Now;
            data.OrderBy = OrderBy;
            data.Type = Type;

            if (!string.IsNullOrWhiteSpace(LogoImgPath))
            {
              try
              {
                var filePath = Path.Combine("~/UploadFile/Slider/" + data.PhotoPath);

                FileInfo File = new FileInfo(filePath);

                if (File.Exists)
                {
                  File.Delete();
                }
              }
              catch (Exception)
              {
                throw;
              }

              data.PhotoPath = LogoImgPath;
            }
            if (string.IsNullOrWhiteSpace(LogoImgPath) && Type == 3)
            {
              try
              {
                var filePath = Path.Combine("~/UploadFile/Slider/" + data.PhotoPath);

                FileInfo File = new FileInfo(filePath);

                if (File.Exists)
                {
                  File.Delete();
                }
              }
              catch (Exception)
              {
                throw;
              }

              data.PhotoPath = LogoImgPath;
            }


            db.SaveChanges();
            result.Success = true;
          }
          else
          {
            result.Success = false;
            result.Message = "Bir Hata Oluştu.Lütfen Tekrar Deneyin";
          }
        }
      }
    }
    catch (Exception)
    {
      result.Success = false;
      result.Message = "Bir Hata Oluştu.Lütfen Tekrar Deneyin";
    }
    return Json(result);
  }
  [AuthenticationGuardAttribute(Page = "Slider")]
  [Route("RemoveSlider"), HttpPost]
  public JsonResult RemoveSlider(long id)
  {
    var _result = new Result();

    try
    {
      using (var db = new DataContext())
      {
        var data = db.Slider.Where(x => x.Id == id).FirstOrDefault();

        var dataLanguage = db.SliderLanguage.Where(x => x.SliderId == id).ToList() ?? new List<SliderLanguage>();

        if (data != null)
        {
          db.Slider.Remove(data);

          for (int i = 0; i < dataLanguage.Count; i++)
          {
            db.SliderLanguage.Remove(dataLanguage[i]);
          }

          try
          {
            var filePath = Path.Combine("~/UploadFile/Slider/" + data.PhotoPath);

            FileInfo File = new FileInfo(filePath);

            if (File.Exists)
            {
              File.Delete();
            }

            var filePath2 = Path.Combine("~/UploadFile/Slider/" + data.SecondPhoto);

            FileInfo File2 = new FileInfo(filePath2);

            if (File2.Exists)
            {
              File2.Delete();
            }
          }
          catch (Exception)
          {
            throw;
          }

          db.SaveChanges();

          _result.Success = true;
        }
        else
        {
          _result.Success = false;
          _result.Message = "Bir Hata Oluştu.Lütfen Tekrar Deneyin";
        }
      }
    }
    catch (Exception)
    {
      _result.Success = false;
      _result.Message = "Bir Hata Oluştu.Lütfen Tekrar Deneyin";
    }

    return Json(_result);
  }
}
