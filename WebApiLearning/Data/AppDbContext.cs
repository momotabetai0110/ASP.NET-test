using Microsoft.EntityFrameworkCore;

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
    public DateTime BirthDate {get; set;}

    public bool Gender {get; set;}

    public string Job {get; set;} = "";

    public int EarlySociable {get; set;}
    public int MidSociable {get; set;}
    public int LateSociable {get; set;}

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}