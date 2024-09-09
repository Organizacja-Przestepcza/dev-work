namespace api.Models;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Username { get; set; }
    public string Bio { get; set; } = string.Empty;
    public List<Connection>? FollowingConnections { get; set; }
    public List<Connection>? FollowedConnections { get; set; }
    public List<Bookmark>? Bookmarks { get; set; }
    public List<Post>? Posts { get; set; }
 
}