using api.Data;
using api.Dtos.PostInteraction;
using api.Enums;
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

    public async Task<PostInteractionSummaryModel> GetAllForPostAsync(string postId)
    {
        var reactionSummary = await _context.PostInteractions
            .Where(x => x.PostId == postId)
            .GroupBy(x => 1) // Group everything into a single group
            .Select(g => new
            {
                Likes = g.Sum(x => x.Type == InteractionType.Like ? 1 : 0),
                Dislikes = g.Sum(x => x.Type == InteractionType.Dislike ? 1 : 0)
            })
            .FirstOrDefaultAsync();

        return new PostInteractionSummaryModel
        {
            Likes = reactionSummary?.Likes ?? 0,
            Dislikes = reactionSummary?.Dislikes ?? 0
        };
    }

    public async Task<List<PostInteraction>> GetAllForUserAsync(int type, string userId)
    {
        var reactions = await _context.PostInteractions
            .Where(x => x.UserId == userId && x.Type == (InteractionType)type).ToListAsync();
        return reactions;
    }

    public async Task<PostInteraction?> GetByIdAsync(string postId, string userId)
    {
        return await _context.PostInteractions.FirstOrDefaultAsync(x => x.PostId == postId && x.UserId == userId);
    }

    public async Task<PostInteraction?> CreateUpdateAsync(PostInteractionUpdateModel postInteractionUpdate)
    {
        var postInteraction = await _context.PostInteractions.FirstOrDefaultAsync(x =>
            x.PostId == postInteractionUpdate.PostId && x.UserId == postInteractionUpdate.UserId);
        if (postInteraction == null)
        {
            var post = await _context.Posts.FindAsync(postInteractionUpdate.PostId);
            if (post == null) return null;
            postInteraction = postInteractionUpdate.ToPostInteraction();
            await _context.PostInteractions.AddAsync(postInteraction);
        }
        else
        {
            postInteraction.Type = postInteractionUpdate.Type;
            postInteraction.Date = DateTime.Now;
        }

        await _context.SaveChangesAsync();
        return postInteraction;
    }

    public async Task<PostInteraction?> DeleteAsync(string postId, string userId)
    {
        var postInteraction =
            await _context.PostInteractions.FirstOrDefaultAsync(x => x.PostId == postId && x.UserId == userId);
        if (postInteraction == null) return null;
        _context.PostInteractions.Remove(postInteraction);
        await _context.SaveChangesAsync();
        return postInteraction;
    }
}