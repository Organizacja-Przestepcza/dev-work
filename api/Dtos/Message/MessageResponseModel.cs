using api.Dtos.AppUser;
using api.Dtos.Chat;

namespace api.Dtos.Message;

public class MessageResponseModel
{
    public string Id { get; set; }
    public UserResponseModel Sender { get; set; }
    public ChatResponseModel Receiver { get; set; }
    public string Content { get; set; }
    public string? ReplyId { get; set; }
    public DateTime SendDate { get; set; }
    public DateTime? ReadDate { get; set; }
    public DateTime? EditDate { get; set; }
}