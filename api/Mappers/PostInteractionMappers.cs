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
            Type = postInteraction.Type
        };
    }

    public static PostInteraction ToPostInteraction(this PostInteractionUpdateModel postInteractionUpdate)
    {
        return new PostInteraction
        {
            Date = DateTime.Now,
            Type = postInteractionUpdate.Type,
            PostId = postInteractionUpdate.PostId,
            UserId = postInteractionUpdate.UserId
        };
    }
}