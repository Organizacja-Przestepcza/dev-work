using api.Dtos.AppUser;
using api.Models;

namespace api.Interfaces;

public interface IUserRepository
{
    Task<List<AppUser>> GetAllAsync();

    Task<AppUser?> GetByIdAsync(string id);

    Task<AppUser?> UpdateAsync(string id, UserUpdateModel userUpdateModel);
}