using api.Dtos.Member;
using api.Models;

namespace api.Mappers;

public static class MemberMappers
{
    public static MemberResponseModel ToMemberResponse(this ChatMember chatMember)
    {
        return new MemberResponseModel
        {
            Id = chatMember.Id,
            Role = chatMember.Role,
            AddedAt = chatMember.AddedAt,
            Chat = chatMember.Chat.ToChatResponseModel(),
            User = chatMember.AppUser.ToUserResponseModel()
        };
    }

    public static ChatMember ToMember(this MemberRequestModel memberRequestModel)
    {
        return new ChatMember
        {
            Role = memberRequestModel.Role,
            AddedAt = DateTime.Now,
            ChatId = memberRequestModel.ChatId,
            UserId = memberRequestModel.UserId
        };
    }
}