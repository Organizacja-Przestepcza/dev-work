using api.Dtos.Chat;
using api.Dtos.User;

namespace api.Dtos.Message;

public class GetMessageDto
{
    public Guid Id { get; set; }
    public GetUserDto Sender { get; set; }
    public GetChatDto Receiver { get; set; }
    public string Content { get; set; }
    public Guid? ReplyId { get; set; }
    public DateTime SendDate { get; set; }
    public DateTime? ReadDate { get; set; }
}