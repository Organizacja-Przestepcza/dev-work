using api.Dtos.Post;
using api.Models;

namespace api.Mappers;

public static class PostMappers
{
    public static PostResponseModel ToPostResponseModel(this Post post)
    {
        var postResponseModel = new PostResponseModel
        {
            Id = post.Id,
            Content = post.Content,
            CreatedAt = post.CreatedAt,
            PreviousPostId = post.PreviousPostId,
            ImageUrls = post.Images,
        };
        if (post.User != null) postResponseModel.User = post.User.ToUserResponseModel();
        return postResponseModel;
    }

    public static Post ToPost(this PostRequestModel postRequestModel)
    {
        var post = new Post
        {
            Content = postRequestModel.Content,
            CreatedAt = DateTime.Now,
            UserId = new Guid().ToString(),
            PreviousPostId = postRequestModel.PreviousPostId,
            Images = postRequestModel.ImageUrls
        };

        return post;
    }
}