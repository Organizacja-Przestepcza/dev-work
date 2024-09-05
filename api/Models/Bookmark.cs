namespace api.Models;

public class Bookmark
{
   public string ID { get; set; }
   public Post Post { get; set; }
   public User User { get; set; }
   public DateTime CreatedAt { get; set; }
}