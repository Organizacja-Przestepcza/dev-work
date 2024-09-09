using api.Dtos.Post;
using api.Dtos.User;

namespace api.Dtos.Bookmark;

public class BookmarkRequestModel
{
    public Guid PostId { get; set; }
    public Guid UserId { get; set; }
}