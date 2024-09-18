using api.Dtos.Chat;
using api.Models;

namespace api.Mappers;

public static class ChatMappers
{
    public static ChatResponseModel ToChatResponseModel(this Chat memberChat)
    {
        return new ChatResponseModel
        {
            Id = memberChat.Id,
            Name = memberChat.Name,
            CreatedAt = memberChat.CreatedAt
        };
    }

    public static Chat ToChat(this ChatRequestModel chatRequestModel)
    {
        return new Chat
        {
            CreatedAt = DateTime.Now,
            Name = chatRequestModel.Name,
            Members = []
        };
    }
}