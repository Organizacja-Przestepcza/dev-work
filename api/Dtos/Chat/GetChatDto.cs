using api.Dtos.Member;

namespace api.Dtos.Chat;

public class GetChatDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<GetMemberDto> Members { get; set; }
}