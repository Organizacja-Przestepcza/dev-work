using System.ComponentModel.DataAnnotations;
using api.Enums;

namespace api.Models;

public class ChatMember
{
    [MaxLength(38)] public string Id { get; set; } = null!;

    public required Role Role { get; set; }
    public required DateTime AddedAt { get; set; }

    [MaxLength(38)] public required string ChatId { get; set; }

    public Chat Chat { get; set; }

    [MaxLength(38)] public required string UserId { get; set; }

    public AppUser AppUser { get; set; }
}