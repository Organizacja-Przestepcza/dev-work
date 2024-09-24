using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Bookmark;

public class BookmarkRequestModel
{
    [Required] public required string PostId { get; set; }
}