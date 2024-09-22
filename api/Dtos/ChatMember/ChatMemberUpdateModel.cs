using System.ComponentModel.DataAnnotations;
using api.Enums;

namespace api.Dtos.ChatMember;

public class ChatMemberUpdateModel
{
    [Required] public required Role Role { get; set; }
}