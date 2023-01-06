using Microsoft.EntityFrameworkCore;

public class LumosDataContext : DbContext
{
  public DbSet<Slider> Sliders { get; set; }

  public DbSet<BlogPost> BlogPosts { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("Lumos_Database_ConnectionString"));

    base.OnConfiguring(optionsBuilder);
  }
}
