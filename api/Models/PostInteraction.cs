using System.ComponentModel.DataAnnotations;
using api.Enums;

namespace api.Models;

public class PostInteraction
{
    public DateTime Date { get; set; } // idk if needed
    public InteractionType Type { get; set; }

    [MaxLength(38)] public string UserId { get; set; } = null!;

    public AppUser User { get; set; }

    [MaxLength(38)] public string PostId { get; set; } = null!;

    public Post Post { get; set; }
}