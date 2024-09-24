using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Message;

public class MessageRequestModel
{
    [Required] public required string ChatId { get; set; }

    [Required]
    [MaxLength(1024, ErrorMessage = "Can't be longer than 1024 characters")]
    public required string Content { get; set; }

    public string? ReplyId { get; set; }
}