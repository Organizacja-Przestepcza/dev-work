using api.Dtos.User;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Interfaces;

public interface IUserRepository
{ 
    public Task<IActionResult> GetAll();

    public Task<IActionResult> GetById(string id);

    public Task<IActionResult> Add(UserRequestModel userRequest);

    public Task<IActionResult> Update(AppUser user);
    public Task<IActionResult> Delete(string id);
}