using api.Dtos.ChatMember;
using api.Models;

namespace api.Mappers;

public static class MemberMappers
{
    public static ChatMemberResponseModel ToMemberResponse(this ChatMember chatMember)
    {
        return new ChatMemberResponseModel
        {
            Id = chatMember.Id,
            Role = chatMember.Role,
            AddedAt = chatMember.AddedAt,
            User = chatMember.AppUser.ToUserResponseModel()
        };
    }

    public static ChatMember ToMember(this ChatMemberRequestModel chatMemberRequestModel)
    {
        return new ChatMember
        {
            Role = chatMemberRequestModel.Role,
            AddedAt = DateTime.Now,
            ChatId = chatMemberRequestModel.ChatId,
            UserId = chatMemberRequestModel.UserId
        };
    }
}