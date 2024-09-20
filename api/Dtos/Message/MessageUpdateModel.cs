using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Message;

public class MessageUpdateModel
{
    [Required] public required string Content { get; set; }
}