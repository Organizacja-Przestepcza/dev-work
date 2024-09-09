using api.Models;

namespace api.Mappers;

public class ImageMappers
{
    public Image ToImage(string imageUrl)
    {
        var image = new Image()
        {
            FilePath = imageUrl,
        };
        return image;
    }
}