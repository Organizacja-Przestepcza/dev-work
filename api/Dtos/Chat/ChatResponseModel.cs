namespace api.Dtos.Chat;

public class ChatResponseModel
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required DateTime CreatedAt { get; set; }
}