using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Bookmark;

public class BookmarkRequestModel
{
    [Required] public required string PostId { get; set; }
    [Required] public required string UserId { get; set; }
}