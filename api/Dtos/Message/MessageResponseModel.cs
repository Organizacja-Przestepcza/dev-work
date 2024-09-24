using api.Dtos.AppUser;

namespace api.Dtos.Message;

public class MessageResponseModel
{
    public required string Id { get; set; }
    public UserResponseModel Sender { get; set; }
    public required string Content { get; set; }
    public string? ReplyId { get; set; }
    public DateTime SendDate { get; set; }
    public DateTime? ReadDate { get; set; }
    public DateTime? EditDate { get; set; }
}