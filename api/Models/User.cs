namespace api.Models;

public class User
{
    public string ID { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Username { get; set; }
    public string? Bio { get; set; }
    
    public List<Bookmark>? Bookmarks { get; set; }
    public List<Post>? Posts { get; set; }
    public List<User>? Followers { get; set; }
}