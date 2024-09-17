using api.Data;
using api.Dtos.AppUser;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<AppUser>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<AppUser?> GetByIdAsync(string id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<AppUser?> UpdateAsync(string id, UserUpdateModel userUpdateModel)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null) return null;
        user.Avatar = userUpdateModel.Avatar;
        user.Bio = userUpdateModel.Bio;
        await _context.SaveChangesAsync();
        return user;
    }
}