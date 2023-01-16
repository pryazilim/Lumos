using Microsoft.AspNetCore.Mvc;

namespace Lumos.Admin.AdminPublicController;

public class AdminPublicController : Controller
{
  [HttpGet]
  public IActionResult Login()
  {
    return View();
  }

  [HttpPost]
  public JsonResult Login(string userName, string password)
  {
    var result = new Result();
    var currentUser = new AdminUser();

    if (string.IsNullOrWhiteSpace(userName))
    {
      result.Success = false;
      result.Message = "Lütfen kullanıcı adı giriniz";
      return Json(result);
    }

    if (string.IsNullOrWhiteSpace(password))
    {
      result.Success = false;
      result.Message = "Lütfen şifre giriniz";
      return Json(result);
    }

    using (var db = new DataContext())
    {
      currentUser = db.AdminUser!.FirstOrDefault(x => x.UserName == userName && x.Password == password);
    }

    if (currentUser == null)
    {
      result.Success = false;
      result.Message = "Kullanıcı bulunamadı";
      return Json(result);
    }

    else
    {
      HttpContext.Session.SetString("CurrentUser", "");
    }

    return Json(result);
  }
}
