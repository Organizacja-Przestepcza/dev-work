using api.Dtos.AppUser;
using api.Dtos.Post;

namespace api.Dtos.Bookmark;

public class BookmarkResponseModel
{
    public required string Id { get; set; }
    public required PostResponseModel Post { get; set; }
    public required DateTime CreatedAt { get; set; }
}