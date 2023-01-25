using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
  public static string ConnectionString = "Data Source=data.pryazilim.com,10000;Initial Catalog=admin_lumos;User ID=lumoshasar;Password=2eo0!U7a2;TrustServerCertificate=True;";

  public DbSet<AdminUser> AdminUser { get; set; }
  public virtual DbSet<Layout> Layout { get; set; }
  public virtual DbSet<Language> Language { get; set; }
  public virtual DbSet<Seo> Seo { get; set; }
  public virtual DbSet<SeoLanguage> SeoLanguage { get; set; }
  public virtual DbSet<About> About { get; set; }
  public virtual DbSet<AboutLanguage> AboutLanguage { get; set; }
  public virtual DbSet<Address> Address { get; set; }
  public virtual DbSet<AddressLanguage> AddressLanguage { get; set; }
  public virtual DbSet<Slider> Slider { get; set; }
  public virtual DbSet<SliderLanguage> SliderLanguage { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlServer(ConnectionString);

    base.OnConfiguring(optionsBuilder);
  }
}
