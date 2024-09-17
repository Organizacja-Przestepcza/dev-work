using api.Dtos.Bookmark;
using api.Dtos.Connection;
using api.Dtos.Post;

namespace api.Dtos.AppUser;

public class UserDetailModel
{
    public string Id { get; set; } = null!;
    public string Email { get; set; }
    public string Username { get; set; }
    public string Bio { get; set; } = string.Empty;
    public List<ConnectionResponseModel>? FollowingConnections { get; set; }
    public List<ConnectionResponseModel>? FollowedConnections { get; set; }
    public List<BookmarkResponseModel>? Bookmarks { get; set; }
    public List<PostResponseModel>? Posts { get; set; }
}