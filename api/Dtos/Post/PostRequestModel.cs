using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Post;

public class PostRequestModel
{
    [Required] public required string Content { get; set; }
    public List<string>? ImageUrls { get; set; }
    public string? PreviousPostId { get; set; }
}