using api.Dtos.Post;

namespace api.Dtos.Bookmark;

public class BookmarkRequestModel
{
    public required string PostId { get; set; }
    public required string UserId { get; set; }
}