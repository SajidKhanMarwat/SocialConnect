using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialConnect.Core.Entities;

namespace SocialConnect.Core.Context;

public class SocialDbContext : IdentityDbContext<User>
{
    public SocialDbContext(DbContextOptions<SocialDbContext> options)
        : base(options)
    {
    }

    public DbSet<Connection> Connections { get; set; }
    public DbSet<Log> Logs { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<UserDetail> UserDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().Property(u => u.Id).HasMaxLength(255);

        modelBuilder.HasDefaultSchema("sc");
    }
}