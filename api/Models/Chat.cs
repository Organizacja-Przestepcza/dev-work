using System.ComponentModel.DataAnnotations;

namespace api.Models;

public class Chat
{
    [MaxLength(256)] public string Id { get; set; } = null!;

    [MaxLength(256)] public required string Name { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required List<ChatMember> Members { get; set; }
}