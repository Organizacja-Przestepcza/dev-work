using api.Dtos.AppUser;
using api.Enums;

namespace api.Dtos.ChatMember;

public class ChatMemberResponseModel
{
    public required string Id { get; set; }
    public required Role Role { get; set; }
    public required DateTime AddedAt { get; set; }
    public required UserResponseModel User { get; set; }
}