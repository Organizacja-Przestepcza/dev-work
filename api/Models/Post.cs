

using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

public class Post
{
    public string Id { get; set; }
  
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? EditedAt { get; set; }
    public string UserId { get; set; }
    public AppUser AppUser { get; set; }
    public List<Image>? Images { get; set; }
    
    public string? PreviousPostId { get; set; }
    
    [NotMapped]
    public Post? PreviousPost { get; set; }
}