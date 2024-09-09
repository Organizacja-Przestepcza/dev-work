using api.Dtos.Image;
using api.Dtos.User;

namespace api.Dtos.Post;

public class PostResponseModel
{
    public Guid Id { get; set; }
  
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }

    public UserResponseModel? User { get; set; }
    public List<ImageResponseModel>? Images { get; set; }
    
    public Guid? PreviousPostId { get; set; }

}