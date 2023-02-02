using Lumos.Areas.Admin.Models.BaseModel;
using Microsoft.AspNetCore.Mvc;
using Lumos.Base;
using System.Drawing;
using System.Net;

namespace Lumos.Admin;

public class AdminPageController : Controller
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

  public AdminPageController(ILogger<AdminPageController> logger, IWebHostEnvironment webHostEnvironment)
  {
    _logger = logger;
     _webHostEnvironment= webHostEnvironment;
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
    var mdl = new Areas.Admin.Models.ViewModel.SliderModel();

     using (var db = new DataContext())
      {
        var _tempSlider = db.Slider.ToList();
        var _tempSliderLang = db.SliderLanguage.ToList();

        mdl.SliderList = (from s in _tempSlider
                          select new Areas.Admin.Models.GeneralModels.SliderModel
                          {
                            Id = s.Id,
                            Type = s.Type,
                            CreatedDate = s.CreatedDate,
                            PhotoPath = s.PhotoPath,
                            OrderBy = s.OrderBy,
                            SecondPhoto = s.SecondPhoto,
                            UpdateDate = s.UpdatedDate,
                            SliderLanguageList = (from s1 in _tempSliderLang
                                                  where s1.SliderId == s.Id
                                                  select new Areas.Admin.Models.GeneralModels.SliderInnerModel
                                                  {
                                                    ButtonTitle = s1.ButtonTitle,
                                                    ButtonUrl = s1.ButtonUrl,
                                                    Id = s1.Id,
                                                    Title = s1.Title,
                                                    UnderTitle = s1.Description,
                                                    LanguageId = s1.LanguageId
                                                  }).ToList() ?? new List<Areas.Admin.Models.GeneralModels.SliderInnerModel>()
                          }).OrderBy(s => s.OrderBy).ToList() ?? new List<Areas.Admin.Models.GeneralModels.SliderModel>();
        mdl.SliderMain = (from s in _tempSlider
                          select new Areas.Admin.Models.GeneralModels.SliderModel
                          {
                            Id = s.Id,
                            Type = s.Type,
                            CreatedDate = s.CreatedDate,
                            PhotoPath = s.PhotoPath,
                            OrderBy = s.OrderBy,
                            SecondPhoto = s.SecondPhoto,
                            UpdateDate = s.UpdatedDate,
                            SliderLanguageList = (from s1 in _tempSliderLang
                                                  where s1.SliderId == s.Id
                                                  select new Areas.Admin.Models.GeneralModels.SliderInnerModel
                                                  {
                                                    ButtonTitle = s1.ButtonTitle,
                                                    ButtonUrl = s1.ButtonUrl,
                                                    Id = s1.Id,
                                                    Title = s1.Title,
                                                    UnderTitle = s1.Description,
                                                    LanguageId = s1.LanguageId
                                                  }).ToList() ?? new List<Areas.Admin.Models.GeneralModels.SliderInnerModel>()
                          }).FirstOrDefault() ?? new Areas.Admin.Models.GeneralModels.SliderModel();
      }
      return View(mdl);
  }

  [HttpGet]
  [AuthenticationGuard(Page = "Index")]
  public IActionResult SliderList()
  {
    var mdl = new Areas.Admin.Models.ViewModel.SliderModel();

     using (var db = new DataContext())
      {
        var _tempSlider = db.Slider.ToList();
        var _tempSliderLang = db.SliderLanguage.ToList();

        mdl.SliderList = (from s in _tempSlider
                          select new Areas.Admin.Models.GeneralModels.SliderModel
                          {
                            Id = s.Id,
                            Type = s.Type,
                            CreatedDate = s.CreatedDate,
                            PhotoPath = s.PhotoPath,
                            OrderBy = s.OrderBy,
                            SecondPhoto = s.SecondPhoto,
                            UpdateDate = s.UpdatedDate,
                            SliderLanguageList = (from s1 in _tempSliderLang
                                                  where s1.SliderId == s.Id
                                                  select new Areas.Admin.Models.GeneralModels.SliderInnerModel
                                                  {
                                                    ButtonTitle = s1.ButtonTitle,
                                                    ButtonUrl = s1.ButtonUrl,
                                                    Id = s1.Id,
                                                    Title = s1.Title,
                                                    UnderTitle = s1.Description,
                                                    LanguageId = s1.LanguageId
                                                  }).ToList() ?? new List<Areas.Admin.Models.GeneralModels.SliderInnerModel>()
                          }).OrderBy(s => s.OrderBy).ToList() ?? new List<Areas.Admin.Models.GeneralModels.SliderModel>();
        mdl.SliderMain = (from s in _tempSlider
                          select new Areas.Admin.Models.GeneralModels.SliderModel
                          {
                            Id = s.Id,
                            Type = s.Type,
                            CreatedDate = s.CreatedDate,
                            PhotoPath = s.PhotoPath,
                            OrderBy = s.OrderBy,
                            SecondPhoto = s.SecondPhoto,
                            UpdateDate = s.UpdatedDate,
                            SliderLanguageList = (from s1 in _tempSliderLang
                                                  where s1.SliderId == s.Id
                                                  select new Areas.Admin.Models.GeneralModels.SliderInnerModel
                                                  {
                                                    ButtonTitle = s1.ButtonTitle,
                                                    ButtonUrl = s1.ButtonUrl,
                                                    Id = s1.Id,
                                                    Title = s1.Title,
                                                    UnderTitle = s1.Description,
                                                    LanguageId = s1.LanguageId
                                                  }).ToList() ?? new List<Areas.Admin.Models.GeneralModels.SliderInnerModel>()
                          }).FirstOrDefault() ?? new Areas.Admin.Models.GeneralModels.SliderModel();
      }
      return View(mdl);
  }

  [HttpGet]
  [AuthenticationGuard(Page = "Index")]
  public IActionResult SliderUpdate(int? I)
  {
    var mdl = new Areas.Admin.Models.ViewModel.SliderModel();

     if (I == null || I == 0)
      {
        mdl.SliderMain = new Areas.Admin.Models.GeneralModels.SliderModel();
      }

      else
      {
         using (var db = new DataContext())
        {
          var slider = db.Slider.Where(x => x.Id == I).FirstOrDefault();
          mdl.SliderMain = new Areas.Admin.Models.GeneralModels.SliderModel()
          {
            Id = slider.Id,
            PhotoPath = slider.PhotoPath,
            Type = slider.Type,
            CreatedDate = slider.CreatedDate,
            SecondPhoto = slider.SecondPhoto,
            UpdateDate = slider.UpdatedDate,
            OrderBy = slider.OrderBy,
            SliderLanguageList = db.SliderLanguage.Where(x => slider.Id == x.SliderId).Select(x => new Areas.Admin.Models.GeneralModels.SliderInnerModel()
            {
              ButtonTitle = x.ButtonTitle,
              ButtonUrl = x.ButtonUrl,
              Title = x.Title,
              UnderTitle = x.Description,
              LanguageId = x.LanguageId,
            }).ToList() ?? new List<Areas.Admin.Models.GeneralModels.SliderInnerModel>()
          };
        }
      }
    return View(mdl);
  }
}
