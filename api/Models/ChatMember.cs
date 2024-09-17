using api.Enums;

namespace api.Models;


public class ChatMember
{
    public string Id { get; set; }
    public Role Role { get; set; }
    public DateTime AddedAt { get; set; }
    public string ChatId { get; set; }
    public Chat Chat { get; set; }
    public string UserId { get; set; }
    public AppUser AppUser { get; set; }
}