using api.Enums;

namespace api.Dtos.Member;

public class MemberRequestModel
{

    public Role Role { get; set; } = Role.Member;
    public string ChatId { get; set; }
    public string UserId { get; set; }

}