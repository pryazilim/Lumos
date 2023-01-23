using Microsoft.AspNetCore.Mvc;

namespace Lumos.Admin;

public class AdminPageController : Controller
{
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

  [AuthenticationGuard(Page = "Index")]
  public IActionResult SliderManagement()
  {
    return View();
  }

}
