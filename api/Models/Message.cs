using System.ComponentModel.DataAnnotations;

namespace api.Models;

public class Message
{
    [MaxLength(38)] public string Id { get; set; } = null!;

    [MaxLength(38)] public required string UserId { get; set; }

    public AppUser Sender { get; set; }

    [MaxLength(38)] public required string ChatId { get; set; }

    public Chat Receiver { get; set; }

    [MaxLength(1024)] public required string Content { get; set; }

    [MaxLength(38)] public string? ReplyId { get; set; }

    public required DateTime SendDate { get; set; }
    public DateTime? ReadDate { get; set; }
}