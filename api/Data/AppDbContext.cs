using System.Diagnostics;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Member> Members { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Bookmark> Bookmarks { get; set; }
    public DbSet<Chat> Chats { get; set; }
    public DbSet<Message> Messages { get; set; }
    //public DbSet<Image> Images { get; set; }
    public DbSet<Connection> Connections { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        SeedInitial(modelBuilder);
        
        modelBuilder.Entity<Connection>()
            .HasOne(c => c.Follower)
            .WithMany(u => u.FollowingConnections)
            .HasForeignKey(c => c.FollowerId)
            .OnDelete(DeleteBehavior.Restrict); 

        modelBuilder.Entity<Connection>()
            .HasOne(c => c.Following)
            .WithMany(u => u.FollowedConnections)
            .HasForeignKey(c => c.FollowingId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    private void SeedInitial(ModelBuilder modelBuilder)
    {
        List<IdentityRole> roles =
        [
            new()
            {
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            },
            new()
            {
                Name = "Moderator",
                NormalizedName = "MODERATOR"
            },
            new()
            {
                Name = "User",
                NormalizedName = "USER"
            }

        ];
        modelBuilder.Entity<IdentityRole>().HasData(roles);
        
        var user = new AppUser()  
        { 
            UserName = "Admin",  
            Email = "admin@admin.com",  
            LockoutEnabled = false,
            NormalizedEmail = "ADMIN@ADMIN.COM",
            NormalizedUserName = "ADMIN",
        };
        
        var pass = new PasswordHasher<AppUser>().HashPassword(user, Environment.GetEnvironmentVariable("ADMIN_PASSWORD"));
        user.PasswordHash = pass;
        modelBuilder.Entity<AppUser>().HasData(user);  
        var adminRole = roles.First(r => r.Name == "Administrator");
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>() { UserId = user.Id, RoleId = adminRole.Id });
    }
}
