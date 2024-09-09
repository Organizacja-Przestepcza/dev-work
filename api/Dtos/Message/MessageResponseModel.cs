using api.Dtos.Chat;
using api.Dtos.User;

namespace api.Dtos.Message;

public class MessageResponseModel
{
    public Guid Id { get; set; }
    public UserResponseModel Sender { get; set; }
    public ChatResponseModel Receiver { get; set; }
    public string Content { get; set; }
    public Guid? ReplyId { get; set; }
    public DateTime SendDate { get; set; }
    public DateTime? ReadDate { get; set; }
}