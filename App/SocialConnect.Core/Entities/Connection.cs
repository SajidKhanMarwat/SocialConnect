namespace SocialConnect.Core.Entities;

public class Connection
{
    public int Id { get; set; }

    public User User { get; set; }

    public bool IsMutual { get; set; }

<<<<<<< Updated upstream
    public bool IsRequestPending { get; set; }
=======
    public ConnectionStatus? FriendShipStatus { get; set; }
>>>>>>> Stashed changes

    public DateTime CreatedOn { get; set; }

    public DateTime AcceptedOn { get; set; }

    public DateTime RejectedOn { get; set; }

    public DateTime UpdatedOn { get; set; }

    public bool IsDeleted {  get; set; }

}