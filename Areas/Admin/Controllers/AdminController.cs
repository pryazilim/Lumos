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
  public IActionResult Index()
  {
    return View();
  }
}
