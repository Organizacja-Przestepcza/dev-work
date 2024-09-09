namespace api.Dtos.Message;

public class MessageRequestModel
{
    public Guid SenderId { get; set; }
    public User Sender { get; set; }
    public Guid ReceiverId { get; set; }
    public Chat Receiver { get; set; }
    public string Content { get; set; }
    public Guid? ReplyId { get; set; }
}