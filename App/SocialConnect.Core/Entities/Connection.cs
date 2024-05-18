using SocialConnect.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace SocialConnect.Core.Entities;

public class Connection
{
    public int Id { get; set; }

    public string? UserId { get; set; }
    public User? User { get; set; }

    public string? FriendWithId { get; set; }
    public User? FriendWith { get; set; }

    public ConnectionStatus Status { get; set; } = ConnectionStatus.Default;

    public DateTime? CreatedOn { get; set; } = DateTime.Now;

    public DateTime? AcceptedOn { get; set; }

    public DateTime? RejectedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public bool IsDeleted { get; set; }

    //public bool IsFriendship => Status == ConnectionStatus.Accepted && !IsDeleted;
}