using System.Security.Claims;

namespace api.Helpers;

public static class CurrentUserHelper
{
    public static string? GetCurrentUserId(HttpContext context)
    {
        return context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    }
}