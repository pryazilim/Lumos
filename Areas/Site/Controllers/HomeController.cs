using Microsoft.AspNetCore.Mvc;

namespace Lumos.SiteControllers;

public class HomeController : Controller
{
  private readonly ILogger<HomeController> _logger;

  public HomeController(ILogger<HomeController> logger)
  {
    _logger = logger;
  }

  public IActionResult Index()
  {
    using (var db = new LumosDataContext())
    {
      // var posts = db.BlogPosts.Where(e => e.PublishedOn.HasValue && e.PublishedOn < DateTime.Now && !e.DeletedOn.HasValue).OrderByDescending(e => e.PublishedOn).Take(10).ToList();

      return View();
    }
  }

  public IActionResult Privacy()
  {
    return View();
  }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View();
  }
}
