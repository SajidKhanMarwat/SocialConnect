using SocialConnect.Core.Enums;
using System.Data;

namespace SocialConnect.Core.Entities;

public class Connection
{
    public int Id { get; set; }

    public User User { get; set; }

    //public User? Friend { get; set; } // Assuming a connection is between two users

    public ConnectionStatus Status { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? AcceptedOn { get; set; }

    public DateTime? RejectedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public bool IsDeleted { get; set; }

    //public bool IsFriendship => Status == ConnectionStatus.Accepted && !IsDeleted;
}