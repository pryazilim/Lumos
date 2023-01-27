using Lumos.Areas.Admin.Models.BaseModel;
using Microsoft.AspNetCore.Mvc;
using Lumos.Base;
using System.Drawing;

namespace Lumos.Admin;

public class AdminPageController : Controller
{
   public List<LanguageModel> LanguageList
    {
      get
      {
        return Statics.getLanguageValues();
      }
    }
  private readonly ILogger<AdminPageController> _logger;

  public AdminPageController(ILogger<AdminPageController> logger)
  {
    _logger = logger;
  }

  [AuthenticationGuard(Page = "Index")]
  public IActionResult Index()
  {
    return View();
  }
  [HttpGet]
  [AuthenticationGuard(Page = "Index")]
  public IActionResult SliderManagement()
  {
    return View();
  }
 [HttpPost]
  public JsonResult SliderManagement(Slider slider)
  {
    var result = new Result();
    try
      {
        var _id = slider.Id;
        var _OrderBy = slider.OrderBy;
        var _Type = slider.Type;
        var TitleArray = new List<LanguageModel>();
        var UnderTitleArray = new List<LanguageModel>();
        var ButtonTitleArray = new List<LanguageModel>();
        var ButtonUrlArray = new List<LanguageModel>();

        var id =_id;
        var OrderBy = _OrderBy;
        var Type = _Type;

        if (OrderBy <= 0)
        {
          result.Success = false;
          result.Message = "Görüntülenme sırası giriniz (0 dan büyük bir değer)";
          return Json(result);
        }

        for (int i = 0; i < LanguageList.Count; i++)
        {
          var Title = System.Net.WebUtility.HtmlDecode("Title" + LanguageList[i].VariableCode);
          var _UnderTitle = "UnderTitle" + LanguageList[i].VariableCode;
          var _ButtonTitle = "ButtonTitle" + LanguageList[i].VariableCode;
          var _ButtonUrl = "ButtonUrl" + LanguageList[i].VariableCode;
          string _title = string.Empty;
          if (!string.IsNullOrWhiteSpace(Title))
          {
            _title = Functions.StripTagsRegexIcerik(Title);
          }
          // Here Control data

          TitleArray.Add(new LanguageModel { LanguageID = LanguageList[i].LanguageID, Value = _title });
          UnderTitleArray.Add(new LanguageModel { LanguageID = LanguageList[i].LanguageID, Value = _UnderTitle });
          ButtonTitleArray.Add(new LanguageModel { LanguageID = LanguageList[i].LanguageID, Value = _ButtonTitle });
          ButtonUrlArray.Add(new LanguageModel { LanguageID = LanguageList[i].LanguageID, Value = _ButtonUrl });
        }

        // TODO:soru-logo
        // var pic = System.Web.HttpContext.Current.Request.Files["Logo"];

         string LogoImgPath = null;

        // if (pic != null)
        // {
        //   var _fileName = Functions.PhotoTitle(pic.FileName.Split('.')[0]);
        //   var _fileNameUniq = Functions.GetUniqueKey(5);
        //   var _fileExtension = Path.GetExtension(pic.FileName);

        //   var images = _fileName + "_" + _fileNameUniq + _fileExtension;

        //   LogoImgPath = images;

        //   var img = Image.FromStream(pic.InputStream);

        //   // string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(@"/UploadFile/Slider"), images);
        //   string path = Path.Combine((@"/UploadFile/Slider"), images);

        //   Functions.CropImage(img, path, 1920, 1080, false, 4);

        //   img.Dispose();
        //   GC.Collect();
        // }


        if (id == 0)
        {
          if (Type != 3)
          {
            if (string.IsNullOrWhiteSpace(LogoImgPath))
            {
              result.Success = false;
              result.Message = "Resim Seçiniz";
              return Json(result);
            }
          }


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
