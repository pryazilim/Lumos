using Microsoft.AspNetCore.Mvc;

namespace Lumos.AdminControllers;

public class AdminHomeController : Controller
{
  private readonly ILogger<AdminHomeController> _logger;

  public AdminHomeController(ILogger<AdminHomeController> logger)
  {
    _logger = logger;
  }

  [AuthenticationGuard]
  public IActionResult SuperSecurePage()
  {
    return View();
  }

  [AuthenticationGuard]
  public IActionResult Index()
  {
    return View();
  }

  [HttpGet]
  public IActionResult Login()
  {
    return View();
  }

  [HttpPost]
  public IActionResult Login(string userName, string password)
  {
    object currentUser = null;

    using (var db = new LumosDataContext())
    {
      //currentUser = db.Users.FirstOrDefault(e => e.UserName == userName && e.Password == password && e.IsActive && !e.IsDeleted && e.IsValidated);
    }

    HttpContext.Session.SetString("CurrentUser", "");

    return View();
  }
}
