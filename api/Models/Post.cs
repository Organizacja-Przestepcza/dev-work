namespace api.Models;

public class Post
{
    public string Id { get; set; }
    public Post? PreviousPost { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }

    public User User { get; set; }
    public List<Image>? Images { get; set; }


}