namespace api.Dtos.PostInteraction;

public class PostInteractionSummaryModel
{
    public int? Likes { get; set; }
    public int? Dislikes { get; set; }
    public int? Score => Likes - Dislikes;
}