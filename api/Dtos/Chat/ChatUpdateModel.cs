using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Chat;

public class ChatUpdateModel
{
    [Required] public required string Name { get; set; }
}