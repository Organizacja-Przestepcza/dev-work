namespace api.Models;

public class Image
{
    public string ID { get; set; }
    public string FilePath { get; set; }
    public Post Post { get; set; }
}