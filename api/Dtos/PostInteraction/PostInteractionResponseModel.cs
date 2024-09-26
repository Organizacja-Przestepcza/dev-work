using api.Enums;

namespace api.Dtos.PostInteraction;

public class PostInteractionResponseModel
{
    public required DateTime Date { get; set; }
    public required InteractionType Type { get; set; }
    public required string UserId { get; set; }
    public required string PostId { get; set; }
}