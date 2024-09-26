using System.ComponentModel.DataAnnotations;
using api.Enums;

namespace api.Dtos.PostInteraction;

public class PostInteractionRequestModel
{
    [Required] public required InteractionType Type { get; set; }
}