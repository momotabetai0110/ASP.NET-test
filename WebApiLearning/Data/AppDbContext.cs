using Microsoft.EntityFrameworkCore;
using MyApp.Models.NightRain;
using MyApp.Models.Test;
using System.ComponentModel.DataAnnotations;

namespace MyApp.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<FaceLog> FaceLogs { get; set; }
    public DbSet<TestEntity> Tests { get; set; }

    public DbSet<NightRainEntity> NightRains { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

}

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int Age { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

public class FaceLog
{
    public int Id { get; set; }

    [Required]
    public DateTime BirthDate { get; set; }

    [Required]
    public bool Gender { get; set; }

    [Required]
    [MaxLength(100)]
    public string Job { get; set; } = "";

    [Required]
    [Range(1, 10)]
    public int EarlySociable { get; set; }
    [Required]
    [Range(1, 10)]
    public int MidSociable { get; set; }
    [Required]
    [Range(1, 10)]
    public int LateSociable { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

public class NightRain
{
    public int Id { get; set; }

    public int Bosses { get; set; }

    public int TerrainEffect { get; set; }
}
