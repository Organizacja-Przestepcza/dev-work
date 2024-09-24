using api.Dtos.Bookmark;
using api.Models;

namespace api.Mappers;

public static class BookmarkMappers
{
    public static BookmarkResponseModel ToBookmarkResponseModel(this Bookmark bookmark)
    {
        return new BookmarkResponseModel
        {
            Id = bookmark.Id,
            CreatedAt = bookmark.CreatedAt,
            Post = bookmark.Post.ToPostResponseModel()
        };
    }

    public static Bookmark ToBookmark(this BookmarkRequestModel bookmarkRequestModel)
    {
        return new Bookmark
        {
            CreatedAt = DateTime.Now,
            UserId = new Guid().ToString(),
            PostId = bookmarkRequestModel.PostId
        };
    }
}