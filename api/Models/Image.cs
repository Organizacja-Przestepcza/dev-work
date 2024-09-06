namespace api.Models;

public class Image
{
    public Guid Id { get; set; }
    public string FilePath { get; set; }
    public Post Post { get; set; }
}