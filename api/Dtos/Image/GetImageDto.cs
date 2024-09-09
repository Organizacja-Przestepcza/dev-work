using api.Dtos.Post;

namespace api.Dtos.Image;

public class GetImageDto
{
    public Guid Id { get; set; }
    public string FilePath { get; set; }
    public GetPostDto Post { get; set; }
}