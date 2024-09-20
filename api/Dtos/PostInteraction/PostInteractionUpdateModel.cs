using System.ComponentModel.DataAnnotations;
using api.Enums;
using Microsoft.VisualBasic;

namespace api.Dtos.PostInteraction;

public class PostInteractionUpdateModel
{
    [Required] public required InteractionType Type { get; set; }
}