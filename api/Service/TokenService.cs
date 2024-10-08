using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using api.Dtos;
using api.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace api.Service;

public class TokenService : ITokenService
{
    private readonly SymmetricSecurityKey _key;

    public TokenService(IConfiguration config)
    {
        var jwtKey = Environment.GetEnvironmentVariable("JWT_KEY")
                     ?? throw new Exception("JWT key cannot be null or empty");

        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
    }

    public string CreateToken(TokenData data)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Email, data.AppUser.Email),
            new(ClaimTypes.Name, data.AppUser.UserName),
            new(ClaimTypes.NameIdentifier, data.AppUser.Id),
            new(ClaimTypes.Role, data.Roles.First())
        };
        var encryption = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = encryption,
            Issuer = Environment.GetEnvironmentVariable("JWT_ISSUER"),
            Audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE")
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}