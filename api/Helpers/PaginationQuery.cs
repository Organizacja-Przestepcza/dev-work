using System.ComponentModel.DataAnnotations;

namespace api.Helpers;

public class PaginationQuery
{
    public int Page { get; set; } = 0;

    [Range(1, 20, ErrorMessage = "Page size must be between 1 and 20")]
    public int Limit { get; set; } = 10;
}