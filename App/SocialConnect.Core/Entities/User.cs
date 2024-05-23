using Microsoft.AspNetCore.Identity;
using SocialConnect.Core.Enums;

namespace SocialConnect.Core.Entities;

public class User : IdentityUser
{
    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsLocked { get; set; }

    public DateTime CreatedOn { get; set; } = DateTime.Now;

    public DateTime UpdatedOn { get; set; } = DateTime.Now;

    public ICollection<Connection> Connections { get; set; }

    public ICollection<Post> Posts { get; set; }

<<<<<<< Updated upstream
    public ICollection<UserDetail> UserDetails { get; set; }
=======
    public ICollection<Post>? Posts { get; set; }

    public UserDetail? UserDetails { get; set; }
    public required UserRole UserRole { get; set; }
>>>>>>> Stashed changes
}