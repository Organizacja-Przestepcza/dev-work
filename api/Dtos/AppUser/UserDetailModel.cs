using api.Dtos.Bookmark;
using api.Dtos.Connection;
using api.Dtos.Post;

namespace api.Dtos.AppUser;

public class UserDetailModel
{
    public required string Id { get; set; }
    public required string Email { get; set; }
    public required string Username { get; set; }
    public string? Bio { get; set; }
    public List<ConnectionResponseModel>? FollowingConnections { get; set; }
    public List<ConnectionResponseModel>? FollowedConnections { get; set; }
    public List<BookmarkResponseModel>? Bookmarks { get; set; }
    public List<PostResponseModel>? Posts { get; set; }
}