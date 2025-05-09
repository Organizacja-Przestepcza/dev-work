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
        modelBuilder.Entity<Bookmark>(entity =>
        {
            entity.HasKey(b => new { b.UserId, b.PostId });

            entity.HasOne(b => b.Post)
                .WithMany(p => p.Bookmarks)
                .HasForeignKey(b => b.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(b => b.AppUser)
                .WithMany(u => u.Bookmarks)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        modelBuilder.Entity<PostInteraction>(entity =>
        {
            entity.HasKey(x => new { x.UserId, x.PostId });

            entity.HasOne(x => x.Post)
                .WithMany(p => p.PostInteractions)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(x => x.User)
                .WithMany(u => u.PostInteractions)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }

    private static void SeedInitial(ModelBuilder modelBuilder)
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