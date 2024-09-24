using api.Dtos.AppUser;
using api.Dtos.Post;

namespace api.Dtos.Bookmark;

public class BookmarkResponseModel
{
    public string? UserId { get; set; }
    public required PostResponseModel Post { get; set; }
    public required DateTime CreatedAt { get; set; }
}