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

        SeedRoles(modelBuilder);
        SeedAdmin(modelBuilder);
        
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

    private void SeedRoles(ModelBuilder modelBuilder)
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
    }

    private void SeedAdmin(ModelBuilder modelBuilder)
    {
        var user = new AppUser()  
        {  
            Id = new Guid().ToString(),  
            UserName = "Admin",  
            Email = "admin@gmail.com",  
            LockoutEnabled = false,  
        };
        
        new PasswordHasher<AppUser>().HashPassword(user, Environment.GetEnvironmentVariable("ADMIN_PASSWORD") ?? throw new InvalidOperationException());
        
        modelBuilder.Entity<AppUser>().HasData(user);  
    }
}
