using api.Dtos.Post;
using api.Dtos.User;

namespace api.Dtos.Bookmark;

public class BookmarkRequestModel
{
    public string PostId { get; set; }
    public string UserId { get; set; }
}