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

        // Created 2 Foreign Keys of the User Entity in the Connection Entity.

        modelBuilder.Entity<Connection>()
            .HasOne(c => c.User)
            .WithMany(u => u.Connections)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Connection>()
            .HasOne(c => c.FriendWith)
            .WithMany()
            .HasForeignKey(c => c.FriendWithId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<User>().Property(u => u.Id).HasMaxLength(255);

        modelBuilder.HasDefaultSchema("sc");
    }
}