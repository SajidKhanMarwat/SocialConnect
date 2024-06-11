using Microsoft.AspNetCore.Identity;
using SocialConnect.Core.Enums;

namespace SocialConnect.Core.Entities;

public class User : IdentityUser
{
    public Gender? Gender { get; set; }
    public string? FullName { get; set; }
    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public bool? IsLocked { get; set; }

    public DateTime CreatedOn { get; set; } = DateTime.Now;

    public DateTime UpdatedOn { get; set; }

    // Relationship with other Entities of this User Entity.
    // 1 to many, ex: 1 user have multiple Posts and connections etc.

    public ICollection<Connection>? Connections { get; set; }

    public ICollection<Post>? Posts { get; set; }
}