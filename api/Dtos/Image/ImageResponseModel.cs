using api.Dtos.Post;

namespace api.Dtos.Image;

public class ImageResponseModel
{
    public string FilePath { get; set; }
    public PostResponseModel Post { get; set; }
}