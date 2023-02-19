using Microsoft.EntityFrameworkCore;

namespace ParksApiContext.Models
{
  public class ParksApiContext : DbContext
  {
    public DbSet<Park> Parks { get; set; }
    
    public ParksApiContext(DbContextOptions<ParksApiContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Park>()
      .HasData(
        new Park { ParkId = 1, ParkName = "Bear Brook", ParkState = "New Hampshire", Municipality = "State" },
        new Park { ParkId = 2, ParkName = "Mammoth Cave", ParkState = "Kentucky", Municipality = "National" }
      );
    }
  }
}