namespace api.Models;

public class Chat
{
    public string ID { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<Member> Members { get; set; }
}