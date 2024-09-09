using api.Dtos.Post;
using api.Dtos.User;
using api.Models;

namespace api.Mappers;

public static class PostMappers
{
    public static PostResponseModel ToPostResponseModel(this Post post)
    {
        var postResponseModel = new PostResponseModel()
        {
            Id = post.Id,
            Content = post.Content,
            CreatedAt = post.CreatedAt,
            User = UserMappers.ToUserResponseModel(post.User),
            PreviousPostId = post.PreviousPostId,
        };
        if (post.Images is not null)
        {
            postResponseModel.ImageUrls = post.Images.Select(i => i.FilePath).ToList();
        }
        return postResponseModel;
    }

    public static Post ToPost(this PostRequestModel postRequestModel)
    {
        var post = new Post()
        {
            Id = new Guid(),
            Content = postRequestModel.Content,
            CreatedAt = DateTime.Now,
            UserId = postRequestModel.UserId,
            PreviousPostId = postRequestModel.PreviousPostId
        };
        if (postRequestModel.ImageUrls is not null)
        {
            post.Images = postRequestModel.ImageUrls.Select(imageUrl => new Image
            {
                Id = Guid.NewGuid(),
                FilePath = imageUrl,
                Post = post 
            }).ToList();
        }
        
        return post;
    }
}