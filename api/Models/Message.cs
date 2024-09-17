using System.ComponentModel.DataAnnotations;

namespace api.Models;

 public class Message
{
    [MaxLength(256)]
    public string Id { get; set; } = null!;

    [MaxLength(256)]
    public required string SenderId { get; set; }
    public AppUser Sender { get; set; }
    [MaxLength(256)]
    public required string ReceiverId { get; set; }
    public Chat Receiver { get; set; }
    [MaxLength(1024)]
    public required string Content { get; set; }
    [MaxLength(256)]
    public string? ReplyId { get; set; }
    public required DateTime SendDate { get; set; }
    public DateTime? ReadDate { get; set; }
}