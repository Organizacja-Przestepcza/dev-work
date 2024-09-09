using api.Dtos.Member;

namespace api.Dtos.Chat;

public class ChatRequestModel
{
 
    public string Name { get; set; }
    public List<Guid> MemberIds { get; set; }
}