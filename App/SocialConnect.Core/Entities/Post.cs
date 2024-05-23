namespace SocialConnect.Core.Entities;

public class Post
{
    public int Id { get; set; }
    public User User { get; set; } // ForeignKey relationshipt wth User Entity
    public required string Title {  get; set; }
    public string Description { get; set; }
    public string? Image {  get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public DateTime UpdatedOn { get; set; }
    public bool IsDeleted { get; set; }
}