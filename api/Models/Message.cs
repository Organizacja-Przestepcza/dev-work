namespace api.Models;

 public class Message
{
    public string ID { get; set; }
    public User Sender { get; set; }
    public Chat Receiver { get; set; }
    public string Content { get; set; }
    public Message? Reply { get; set; }
    public DateTime SendDate { get; set; }
    public DateTime? ReadDate { get; set; }
}