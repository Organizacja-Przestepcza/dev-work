namespace api.Dtos.Post;

public class PostDto
{
    public Guid Id { get; set; }
  
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }

    public User? User { get; set; }
    public List<Image>? Images { get; set; }
    
    public string? PreviousPostId { get; set; }
    
    [NotMapped]
    public Post? PreviousPost { get; set; }
}