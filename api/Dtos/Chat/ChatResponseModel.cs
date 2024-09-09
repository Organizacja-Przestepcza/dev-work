using api.Dtos.Member;

namespace api.Dtos.Chat;

public class ChatResponseModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
}