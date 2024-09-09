using api.Dtos.Image;
using api.Dtos.User;

namespace api.Dtos.Post;

public class GetPostDto
{
    public Guid Id { get; set; }
  
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }

    public GetUserDto? User { get; set; }
    public List<ImageDto>? Images { get; set; }
    
    public Guid? PreviousPostId { get; set; }

}