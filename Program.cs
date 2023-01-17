var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{
  options.IdleTimeout = TimeSpan.FromMinutes(30);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();

  app.UseHttpsRedirection();
}

app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapAreaControllerRoute(
    name: "AdminLogin",
    areaName: "Admin",
    pattern: "admin/login/{controller=AdminPublic}/{action=Login}");

app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "Admin/{controller=AdminPage}/{action=Index}");

app.MapAreaControllerRoute(
  name: "Calculation",
  areaName: "Site",
  pattern: "calculation/{controller=Home}/{action=Calculation}/{id?}");

app.MapAreaControllerRoute(
  name: "Contact",
  areaName: "Site",
  pattern: "contact/{controller=Home}/{action=Contact}/{id?}");

app.MapAreaControllerRoute(
  name: "FAQ",
  areaName: "Site",
  pattern: "faq/{controller=Home}/{action=FAQ}/{id?}");

app.MapAreaControllerRoute(
  name: "NewsDetail",
  areaName: "Site",
  pattern: "news-detail/{controller=Home}/{action=NewsDetail}/{id?}");

app.MapAreaControllerRoute(
    name: "News",
    areaName: "Site",
    pattern: "news/{controller=Home}/{action=News}/{id?}");

app.MapAreaControllerRoute(
  name: "PrecedentDecisionDetail",
  areaName: "Site",
  pattern: "precedent-decision-detail/{controller=Home}/{action=PrecedentDecisionDetail}/{id?}");

app.MapAreaControllerRoute(
    name: "PrecedentDecision",
    areaName: "Site",
    pattern: "precedent-decision/{controller=Home}/{action=PrecedentDecision}/{id?}");


app.MapAreaControllerRoute(
    name: "ServicesDetail",
    areaName: "Site",
    pattern: "services-detail/{controller=Home}/{action=ServicesDetail}/{id?}");


app.MapAreaControllerRoute(
    name: "Services",
    areaName: "Site",
    pattern: "services/{controller=Home}/{action=Services}/{id?}");

app.MapAreaControllerRoute(
    name: "About",
    areaName: "Site",
    pattern: "about/{controller=Home}/{action=About}/{id?}");

app.MapAreaControllerRoute(
    name: "default",
    areaName: "Site",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
