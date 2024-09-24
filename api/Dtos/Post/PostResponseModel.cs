using api.Dtos.AppUser;

namespace api.Dtos.Post;

public class PostResponseModel
{
    public required string Id { get; set; }
    public required string Content { get; set; }
    public required DateTime CreatedAt { get; set; }

    public DateTime? EditedAt { get; set; }
    public int CommentCount { get; set; }
    public UserResponseModel User { get; set; }
    public List<string>? ImageUrls { get; set; }

    public string? PreviousPostId { get; set; }
}