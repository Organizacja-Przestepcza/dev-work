using api.Dtos.Bookmark;
using api.Models;

namespace api.Mappers;

public class BookmarkMappers
{
    public static BookmarkResponseModel ToBookmarkResponseModel(Bookmark bookmark)
    {
        return new BookmarkResponseModel
        {
            Id = bookmark.Id,
            CreatedAt = bookmark.CreatedAt,
            Post = PostMappers.ToPostResponseModel(bookmark.Post),
            User = UserMappers.ToUserResponseModel(bookmark.User),
        };
    }

    public static Bookmark ToBookmark(BookmarkRequestModel bookmarkRequestModel)
    {
        return new Bookmark
        {
            Id = new Guid(),
            CreatedAt = DateTime.Now,
        };
    }
}