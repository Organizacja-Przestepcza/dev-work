using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace api.Models;

public class AppUser : IdentityUser
{
    [MaxLength(256)] public string? Bio { get; set; }

    [MaxLength(256)] public string? Avatar { get; set; }

    public List<Connection>? FollowingConnections { get; set; }
    public List<Connection>? FollowedConnections { get; set; }
    public List<Bookmark>? Bookmarks { get; set; }
    public List<Post>? Posts { get; set; }
}