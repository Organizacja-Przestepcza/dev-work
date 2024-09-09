using api.Dtos.Post;
using api.Dtos.User;

namespace api.Dtos.Bookmark;

public class BookmarkDto
{
    public Guid Id { get; set; }
    public GetPostDto Post { get; set; }
    public GetUserDto User { get; set; }
    public DateTime CreatedAt { get; set; }
}