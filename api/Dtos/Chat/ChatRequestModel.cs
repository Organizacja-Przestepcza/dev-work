using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Chat;

public class ChatRequestModel
{
    [Required]
    [MaxLength(256, ErrorMessage = "Can't be longer than 256 characters")]
    public required string Name { get; set; }
}