using api.Dtos.AppUser;

namespace api.Dtos.Post;

public class PostResponseModel
{
    public string Id { get; set; }
  
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }

    public UserResponseModel User { get; set; } = null!;
    public List<string>? ImageUrls { get; set; }
    
    public string? PreviousPostId { get; set; }

}