using System.ComponentModel.DataAnnotations;
using api.Enums;

namespace api.Dtos.PostInteraction;

public class PostInteractionUpdateModel
{
    public InteractionType Type { get; set; }
    public required string PostId { get; set; }
    public required string UserId { get; set; }
}