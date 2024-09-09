using api.Dtos.Post;
using api.Dtos.User;
using api.Models;

namespace api.Mappers;

public class PostMappers
{
    public PostResponseModel ToPostResponseModel(Post post)
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

    public Post ToPost(PostRequestModel postRequestModel)
    {
        var post = new Post()
        {
            Id = new Guid(),
            Content = postRequestModel.Content,
            CreatedAt = DateTime.Now,
            UserId = postRequestModel.UserId,
            PreviousPostId = postRequestModel.PreviousPostId
        };
        if (postRequestModel.Images is not null)
        {
            //post.Images = postRequestModel.Images;
        }
        return post;
    }
}