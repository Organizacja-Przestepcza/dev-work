using api.Data;
using api.Dtos.Chat;
using api.Dtos.Member;
using api.Models;

namespace api.Mappers;

public static class MemberMappers
{
    public static MemberResponseModel ToMemberResponse(this Member member)
    {

        return new MemberResponseModel
        {
            Id = member.Id,
            Role = member.Role,
            AddedAt = member.AddedAt,
            Chat = member.Chat.ToChatResponseModel(),
            User = member.User.ToUserResponseModel()
        };
    }

    public static Member ToMember(this MemberRequestModel memberRequestModel)
    {
        return new Member
        {
            Id = new Guid(),
            Role = memberRequestModel.Role,
            AddedAt = DateTime.Now,
            ChatId = memberRequestModel.ChatId,
            UserId = memberRequestModel.UserId,
        };
    }
}