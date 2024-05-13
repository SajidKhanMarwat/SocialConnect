using SocialConnect.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialConnect.Application.DTOs.User
{
    public record UserDTO
        (
            int Id,
            string? Name,
            string? Email
            //string Password,
            //bool IsActive,
            //bool IsDeleted,
            //bool IsLocked,
            //DateTime CreatedOn,
            //DateTime UpdatedOn,
            //IQueryable<Posts> User_Posts,
            //ICollection<UserRoles> User_Roles,
            //ICollection<Connections> User_Connections
        );
}
