using api.Dtos.Post;
using api.Dtos.User;

namespace api.Dtos.Bookmark;

public class BookmarkRequestModel
{
    public PostResponseModel Post { get; set; }
    public UserResponseModel User { get; set; }
    public DateTime CreatedAt { get; set; }
}