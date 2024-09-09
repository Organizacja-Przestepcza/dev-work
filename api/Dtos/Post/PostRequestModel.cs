
namespace api.Dtos.Post;

public class PostRequestModel
{
    public string Content { get; set; }
    public Guid UserId { get; set; }
    public List<string>? ImageUrls { get; set; }
    
    public Guid? PreviousPostId { get; set; }
}