using api.Dtos.Bookmark;
using api.Models;

namespace api.Mappers;

public static class BookmarkMappers
{
    public static BookmarkResponseModel ToBookmarkResponseModel(this Bookmark? bookmark)
    {
        return new BookmarkResponseModel
        {
            CreatedAt = bookmark.CreatedAt,
            Post = null
        };
    }
}