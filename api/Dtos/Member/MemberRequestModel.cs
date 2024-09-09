using api.Enums;

namespace api.Dtos.Member;

public class MemberRequestModel
{

    public Role Role { get; set; } = Role.Member;
    public Guid ChatId { get; set; }
    public Guid UserId { get; set; }

}