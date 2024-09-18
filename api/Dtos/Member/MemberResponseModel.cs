using api.Dtos.AppUser;
using api.Dtos.Chat;
using api.Enums;

namespace api.Dtos.Member;

public class MemberResponseModel
{
    public string Id { get; set; } = null!;
    public Role Role { get; set; }
    public DateTime AddedAt { get; set; }

    public ChatResponseModel Chat { get; set; }
    public UserResponseModel User { get; set; }
}