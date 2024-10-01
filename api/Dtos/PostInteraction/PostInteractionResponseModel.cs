using api.Enums;

namespace api.Dtos.PostInteraction;

public class PostInteractionResponseModel
{
    public DateTime Date { get; set; }
    public required InteractionType Type { get; set; }
    public required string PostId { get; set; }
}