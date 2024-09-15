using api.Dtos.AppUser;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Interfaces;

public interface IUserRepository
{ 
    Task<List<AppUser>> GetAll();

    Task<AppUser?> GetById(string id);

    Task<AppUser?> Update(string id, UserUpdateModel userUpdateModel);
}