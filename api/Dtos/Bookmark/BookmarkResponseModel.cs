using api.Dtos.Post;
using api.Dtos.User;

namespace api.Dtos.Bookmark;

public class BookmarkResponseModel
{
    public Guid Id { get; set; }
    public PostResponseModel Post { get; set; }
    public UserResponseModel User { get; set; }
    public DateTime CreatedAt { get; set; }
}