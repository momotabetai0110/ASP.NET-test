using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

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