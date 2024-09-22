using System.ComponentModel.DataAnnotations;
using api.Enums;

namespace api.Dtos.PostInteraction;

public class PostInteractionRequestModel
{
    [Required] public required InteractionType Type { get; set; }
    [Required] public required string UserId { get; set; }
    [Required] public required string PostId { get; set; }
}