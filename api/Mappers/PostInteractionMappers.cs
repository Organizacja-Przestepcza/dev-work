using api.Dtos.PostInteraction;
using api.Models;

namespace api.Mappers;

public static class PostInteractionMappers
{
    public static PostInteractionResponseModel ToPostInteractionResponseModel(this PostInteraction postInteraction)
    {
        return new PostInteractionResponseModel
        {
            Date = postInteraction.Date,
            PostId = postInteraction.PostId,
            Type = postInteraction.Type,
            UserId = postInteraction.UserId
        };
    }

    public static PostInteraction ToPostInteraction(this PostInteractionRequestModel postInteractionRequest)
    {
        return new PostInteraction
        {
            Date = DateTime.Now,
            Type = postInteractionRequest.Type
        };
    }
}