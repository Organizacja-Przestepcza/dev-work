using api.Dtos.AppUser;
using api.Models;
using Microsoft.AspNetCore.Identity;

namespace api.Mappers;

public static class UserMappers
{
    public static UserResponseModel ToUserResponseModel(this AppUser appUser)
    {
        return new UserResponseModel
        {
          //  Id = appUser.Id,
            Email = appUser.Email,
            Username = appUser.UserName 
        };
    }

    public static async Task<IdentityResult> SetUserPasswordAsync(UserManager<AppUser> userManager, AppUser appUser, string password)
    {
        var result = await userManager.AddPasswordAsync(appUser, password);
        return result;
    }
}