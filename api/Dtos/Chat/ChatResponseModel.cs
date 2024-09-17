using api.Dtos.Member;

namespace api.Dtos.Chat;

public class ChatResponseModel
{
    public string Id { get; set; } = null!;
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
}