namespace SocialConnect.Core.Entities;

public class Connection
{
    public int Id { get; set; }

    public User User { get; set; }

    public bool IsMutual { get; set; }

    public bool IsRequestPending { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime AcceptedOn { get; set; }

    public DateTime RejectedOn { get; set; }

    public DateTime UpdatedOn { get; set; }

    public bool IsDeleted {  get; set; }

}