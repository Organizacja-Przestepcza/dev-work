using api.Dtos.Message;
using api.Dtos.User;
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
            Receiver = message.Receiver.ToChatResponseModel(),
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
            SenderId = messageRequestModel.SenderId,
            ReceiverId = messageRequestModel.ReceiverId,
            SendDate = DateTime.Now,
            ReplyId = messageRequestModel.ReplyId
        };
    }
}