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

    public DbSet<ChatMember> Members { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Bookmark> Bookmarks { get; set; }
    public DbSet<Chat> Chats { get; set; }

    public DbSet<Message> Messages { get; set; }


    public DbSet<Connection> Connections { get; set; }
    public DbSet<PostInteraction> PostInteractions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        SeedInitial(modelBuilder);

        modelBuilder.Entity<Connection>(entity =>
        {
            // Configure composite key (FollowerId, FollowingId)
            entity.HasKey(c => new { c.FollowerId, c.FollowingId });

            // Set up relationships
            entity.HasOne(c => c.Follower)
                .WithMany(u => u.FollowingConnections)
                .HasForeignKey(c => c.FollowerId)
                .OnDelete(DeleteBehavior.Cascade); // When the follower is deleted, cascade delete the connection

            entity.HasOne(c => c.Following)
                .WithMany(u => u.FollowersConnections)
                .HasForeignKey(c => c.FollowingId)
                .OnDelete(DeleteBehavior.Cascade);
        });
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
    }
}