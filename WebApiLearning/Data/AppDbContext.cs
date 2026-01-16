using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<FaceLog> FaceLogs {get; set;}
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
    public int Id {get; set;}

    [Required]
    public DateTime BirthDate {get; set;}

    [Required]
    public bool Gender {get; set;}

    [Required]
    [MaxLength(100)]
    public string Job {get; set;} = "";

    [Required]
    [Range(1, 10)]
    public int EarlySociable {get; set;}
    [Required]
    [Range(1, 10)]
    public int MidSociable {get; set;}
    [Required]
    [Range(1, 10)]
    public int LateSociable {get; set;}

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}