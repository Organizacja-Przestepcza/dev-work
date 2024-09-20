using api.Dtos.PostInteraction;
using api.Enums;
using api.Models;
using Microsoft.VisualBasic;

namespace api.Mappers;

public static class InteractionMappers
{
    public static PostInteractionResponseModel ToPostInteractionResponseModel(PostInteraction postInteraction)
    {
        return new PostInteractionResponseModel
        {
            Id = postInteraction.Id,
            Date = postInteraction.Date,
            PostId = postInteraction.PostId,
            Type = postInteraction.Type,
            UserId = postInteraction.UserId
        };
    }

    public static PostInteraction ToPostInteraction(PostInteractionRequestModel postInteractionRequest)
    {
        return new PostInteraction
        {
            Date = DateTime.Now,
            Type = postInteractionRequest.Type,
            UserId = postInteractionRequest.UserId,
            PostId = postInteractionRequest.PostId
        };
    }
}