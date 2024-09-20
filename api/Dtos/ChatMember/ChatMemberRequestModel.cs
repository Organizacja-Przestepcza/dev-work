using System.ComponentModel.DataAnnotations;
using api.Enums;

namespace api.Dtos.ChatMember;

public class ChatMemberRequestModel
{
    public Role Role { get; set; } = Role.Member;
    [Required] public required string ChatId { get; set; }
    [Required] public required string UserId { get; set; }
}