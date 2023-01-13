using Microsoft.AspNetCore.Mvc;

namespace Lumos.AdminControllers;

public class AdminController : Controller
{
  private readonly ILogger<AdminController> _logger;

  public AdminController(ILogger<AdminController> logger)
  {
    _logger = logger;
  }

  public IActionResult SuperSecurePage()
  {
    return View();
  }

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
