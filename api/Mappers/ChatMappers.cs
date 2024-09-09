using api.Dtos.Chat;
using api.Models;

namespace api.Mappers;

public class ChatMappers
{
    public static ChatResponseModel ToChatResponseModel(Chat memberChat)
    {
        return new ChatResponseModel
        {
            Id = memberChat.Id,
            Name = memberChat.Name,
            CreatedAt = memberChat.CreatedAt,
        };
    }

    public static Chat ToChat(ChatRequestModel chatRequestModel)
    {
        return new Chat
        {
            Id = Guid.NewGuid(),
            CreatedAt = DateTime.Now,
            Name = chatRequestModel.Name,
        };
    }
}