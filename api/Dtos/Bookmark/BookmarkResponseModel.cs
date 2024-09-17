using api.Dtos.AppUser;
using api.Dtos.Post;

namespace api.Dtos.Bookmark;

public class BookmarkResponseModel
{
    public string Id { get; set; } = null!;
    public PostResponseModel Post { get; set; }
    public UserResponseModel User { get; set; }
    public DateTime CreatedAt { get; set; }
}