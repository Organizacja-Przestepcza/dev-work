using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Message;

public class MessageUpdateModel
{
    [Required]
    [MaxLength(1024, ErrorMessage = "Can't be longer than 1024 characters")]
    public required string Content { get; set; }
}