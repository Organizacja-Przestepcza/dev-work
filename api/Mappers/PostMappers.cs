using api.Dtos.Post;
using api.Dtos.User;
using api.Models;

namespace api.Mappers;

public class PostMappers
{
    public PostResponseModel ToPostResponseModel(Post post)
    {
        return new PostResponseModel()
        {
            Id = post.Id,
            Content = post.Content,
            CreatedAt = post.CreatedAt,
            User = UserMappers.ToUserResponseModel(post.User),
            //Images = post.Images,
            PreviousPostId = post.PreviousPostId,
        };
    }
}