using api.Enums;

namespace api.Models;

public class UserPostInteraction
{
    public string Id { get; set; } = null!;
    public DateTime Date { get; set; } // idk if needed
    public InteractionType Type { get; set; }
    
    public string UserId { get; set; } = null!;
    public AppUser User { get; set; } = null!;
    public string PostId { get; set; } = null!;
    public Post Post { get; set; } = null!;
}
