using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Message;

public class MessageRequestModel
{
    [Required] public required string SenderId { get; set; }
    [Required] public required string ReceiverId { get; set; }
    [Required] public required string Content { get; set; }
    public string? ReplyId { get; set; }
}