using Microsoft.AspNetCore.Identity;

namespace api.Models;

public class AppUser:IdentityUser
{
    public string Bio { get; set; } = string.Empty;
    public string Avatar { get; set; }
    public List<Connection>? FollowingConnections { get; set; }
    public List<Connection>? FollowedConnections { get; set; }
    public List<Bookmark>? Bookmarks { get; set; }
    public List<Post>? Posts { get; set; }
 
}