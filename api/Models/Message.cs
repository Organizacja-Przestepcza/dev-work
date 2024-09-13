namespace api.Models;

 public class Message
{
    public string Id { get; set; }
    public string SenderId { get; set; }
    public AppUser Sender { get; set; }
    public string ReceiverId { get; set; }
    public Chat Receiver { get; set; }
    public string Content { get; set; }
    public string? ReplyId { get; set; }
    public DateTime SendDate { get; set; }
    public DateTime? ReadDate { get; set; }
}