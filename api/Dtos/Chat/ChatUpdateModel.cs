using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Chat;

public class ChatUpdateModel
{
    [Required]
    [MaxLength(256, ErrorMessage = "Can't be longer than 256 characters")]
    public required string Name { get; set; }

    [Required] public required string Avatar { get; set; }
}