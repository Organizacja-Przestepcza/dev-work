namespace api.Dtos;

public class TokenData
{
    public TokenData(Models.AppUser user, List<string>? roles)
    {
        AppUser = user;
        Roles = roles ?? [];
    }
    public Models.AppUser AppUser { get; set; }
    public List<string> Roles { get; set; }
}