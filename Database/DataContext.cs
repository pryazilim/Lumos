using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
  public static string ConnectionString = "Data Source=data.pryazilim.com,10000;Initial Catalog=admin_lumos;User ID=lumoshasar;Password=2eo0!U7a2;TrustServerCertificate=True;";

  public DbSet<AdminUser> AdminUser { get; set; }
  public  DbSet<Layout> Layout { get; set; }
  public  DbSet<Language> Language { get; set; }
  public  DbSet<Seo> Seo { get; set; }
  public  DbSet<SeoLanguage> SeoLanguage { get; set; }
  public  DbSet<About> About { get; set; }
  public  DbSet<AboutLanguage> AboutLanguage { get; set; }
  public  DbSet<Address> Address { get; set; }
  public  DbSet<AddressLanguage> AddressLanguage { get; set; }
  public  DbSet<Slider> Slider { get; set; }
  public  DbSet<SliderLanguage> SliderLanguage { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlServer(ConnectionString);

    base.OnConfiguring(optionsBuilder);
  }
}
