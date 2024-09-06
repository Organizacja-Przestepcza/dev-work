using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Bookmark> Bookmarks { get; set; }
    public DbSet<Chat> Chats { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Image> Images { get; set; }

}
