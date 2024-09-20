using System.ComponentModel.DataAnnotations;

namespace api.Models;

public class Post
{
    [MaxLength(256)] public string Id { get; set; } = null!;

    [MaxLength(1024)] public required string Content { get; set; }

    public required DateTime CreatedAt { get; set; }
    public DateTime? EditedAt { get; set; }

    [MaxLength(256)] public required string UserId { get; set; }

    public AppUser? User { get; set; }
    public List<string>? Images { get; set; }

    [MaxLength(256)] public string? PreviousPostId { get; set; }

    public Post? PreviousPost { get; set; }
    public List<PostInteraction>? PostInteractions { get; set; }
}