using api.Dtos.Image;

namespace api.Dtos.Post;

public class PostRequestModel
{
    public string Content { get; set; }
    public Guid UserId { get; set; }
    public List<ImageResponseModel>? Images { get; set; }
    
    public Guid? PreviousPostId { get; set; }
}