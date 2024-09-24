using api.Dtos.Message;
using api.Models;

namespace api.Mappers;

public static class MessageMappers
{
    public static MessageResponseModel ToMessageResponseModel(this Message message)
    {
        return new MessageResponseModel
        {
            Id = message.Id,
            Content = message.Content,
            ReadDate = message.ReadDate,
            ReplyId = message.ReplyId,
            SendDate = message.SendDate,
            Sender = message.Sender.ToUserResponseModel()
        };
    }

    public static Message ToMessage(this MessageRequestModel messageRequestModel)
    {
        return new Message
        {
            Content = messageRequestModel.Content,
            UserId = new Guid().ToString(),
            ChatId = messageRequestModel.ChatId,
            SendDate = DateTime.Now,
            ReplyId = messageRequestModel.ReplyId
        };
    }
}