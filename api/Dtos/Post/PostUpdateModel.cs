using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Post;

public class PostUpdateModel
{
    [Required] public required string Content { get; set; }
    public List<string>? ImageUrls { get; set; }
}