using api.Data;
using api.Dtos.PostInteraction;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class PostInteractionRepository : IPostInteractionRepository
{
    private readonly AppDbContext _context;

    public PostInteractionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<PostInteraction>> GetAllAsync()
    {
        return await _context.PostInteractions.ToListAsync();
    }

    public async Task<PostInteraction?> GetByIdAsync(string id)
    {
        return await _context.PostInteractions.FindAsync(id);
    }

    public async Task<PostInteraction> CreateAsync(PostInteractionRequestModel postInteractionRequest)
    {
        var postInteraction = postInteractionRequest.ToPostInteraction();
        postInteraction.Id = Guid.NewGuid().ToString();
        await _context.PostInteractions.AddAsync(postInteraction);
        await _context.SaveChangesAsync();
        return postInteraction;
    }

    public async Task<PostInteraction?> UpdateAsync(string id, PostInteractionUpdateModel postInteractionUpdate)
    {
        var postInteraction = await _context.PostInteractions.FindAsync(id);
        if (postInteraction == null) return null;
        postInteraction.Type = postInteractionUpdate.Type;
        await _context.SaveChangesAsync();
        return postInteraction;
    }

    public async Task<PostInteraction?> DeleteAsync(string id)
    {
        var postInteraction = await _context.PostInteractions.FindAsync(id);
        if (postInteraction == null) return null;
        _context.PostInteractions.Remove(postInteraction);
        await _context.SaveChangesAsync();
        return postInteraction;
    }
}