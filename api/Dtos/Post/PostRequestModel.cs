namespace api.Dtos.Post;

public class PostRequestModel
{
    public string Content { get; set; }
    public string UserId { get; set; }
    public List<string>? ImageUrls { get; set; }

    public string? PreviousPostId { get; set; }
}