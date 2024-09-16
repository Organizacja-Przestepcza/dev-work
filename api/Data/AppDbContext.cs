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

        List<IdentityRole> roles = new List<IdentityRole>()
        {
            new IdentityRole()
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole()
            {
                Name = "Member",
                NormalizedName = "MEMBER"
            },
        };
        modelBuilder.Entity<IdentityRole>().HasData(roles);
        
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
}
