

using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

public class Post
{
    public Guid Id { get; set; }
  
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }

    public User? User { get; set; }
    public List<Image>? Images { get; set; }
    
    public Guid? PreviousPostId { get; set; }
    
    [NotMapped]
    public Post? PreviousPost { get; set; }
}