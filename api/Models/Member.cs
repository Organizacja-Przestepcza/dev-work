using api.Enums;

namespace api.Models;


public class Member
{
    public Guid Id { get; set; }
    public Role Role { get; set; }
    public DateTime AddedAt { get; set; }
    
    public Chat Chat { get; set; }
    public User User { get; set; }
}