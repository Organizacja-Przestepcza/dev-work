namespace api.Dtos.Message;

public class MessageRequestModel
{
    public string SenderId { get; set; }
    public string ReceiverId { get; set; }
    public string Content { get; set; } = null!;
    public string? ReplyId { get; set; }
}