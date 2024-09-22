using api.Dtos;
using api.Models;

namespace api.Interfaces;

public interface ITokenService
{
    string CreateToken(TokenData data);
}