using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Chat;

public class ChatRequestModel
{
    [Required] public required string Name { get; set; }
    [Required] public required string UserId { get; set; }
}