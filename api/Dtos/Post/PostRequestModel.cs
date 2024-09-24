using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Post;

public class PostRequestModel
{
    [Required]
    [MaxLength(1024, ErrorMessage = "Can't be longer than 1024 characters")]
    public required string Content { get; set; }

    public List<string>? ImageUrls { get; set; }
    public string? PreviousPostId { get; set; }
}