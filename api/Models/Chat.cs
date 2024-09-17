namespace api.Models;

public class Chat
{
    public string Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<ChatMember> Members { get; set; }
}