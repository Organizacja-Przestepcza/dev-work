namespace api.Models;

public class Chat
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<Member> Members { get; set; }
}