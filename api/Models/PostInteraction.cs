using System.ComponentModel.DataAnnotations;
using api.Enums;

namespace api.Models;

public class PostInteraction
{
    [MaxLength(256)] public string Id { get; set; } = null!;
    public DateTime Date { get; set; } // idk if needed
    public InteractionType Type { get; set; }

    [MaxLength(256)] public required string UserId { get; set; }

    public AppUser User { get; set; }

    [MaxLength(256)] public required string PostId { get; set; }

    public Post Post { get; set; }
}