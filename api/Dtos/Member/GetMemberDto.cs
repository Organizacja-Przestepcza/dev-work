using api.Dtos.Chat;
using api.Dtos.User;
using api.Enums;

namespace api.Dtos.Member;

public class GetMemberDto
{
    public Guid Id { get; set; }
    public Role Role { get; set; }
    public DateTime AddedAt { get; set; }
    
    public GetChatDto GetChat { get; set; }
    public GetUserDto User { get; set; }
}