namespace api.Dtos.Message;

public class MessageRequestModel
{
    public Guid SenderId { get; set; }
    public Guid ReceiverId { get; set; }
    public string Content { get; set; } = null!;
    public Guid? ReplyId { get; set; }
}