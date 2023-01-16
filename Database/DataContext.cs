using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
  public DbSet<AdminUser>? AdminUser { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("Lumos_Database_ConnectionString"));

    base.OnConfiguring(optionsBuilder);
  }
}
