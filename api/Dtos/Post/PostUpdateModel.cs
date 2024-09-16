namespace api.Dtos.Post;

public class PostUpdateModel
{
    public string Content { get; set; }
    public List<string>? ImageUrls { get; set; }
}