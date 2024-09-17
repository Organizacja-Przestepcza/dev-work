using api.Dtos.AppUser;

namespace api.Dtos.Post;

public class PostResponseModel
{
    public string Id { get; set; } = null!;
    public string Content { get; set; } = null!;
    public DateTime CreatedAt { get; set; }

    public DateTime? EditedAt { get; set; }
    public UserResponseModel User { get; set; } = null!;
    public List<string>? ImageUrls { get; set; }

    public string? PreviousPostId { get; set; }
}