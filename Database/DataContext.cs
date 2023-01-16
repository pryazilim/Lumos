using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
  public static string ConnectionString = "Data Source=data.pryazilim.com,10000;Initial Catalog=admin_lumos;User ID=lumoshasar;Password=2eo0!U7a2;TrustServerCertificate=True;";

  public DbSet<AdminUser>? AdminUser { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlServer(ConnectionString);

    base.OnConfiguring(optionsBuilder);
  }
}
