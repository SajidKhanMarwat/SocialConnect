using SocialConnect.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace SocialConnect.Application.DTOs.User
{
    public record UserDTO
        (
            string Id,
            string Name,
            DateTimeOffset? LockoutEnd,
            bool TwoFactorEnabled,
            bool PhoneNumberConfirmed,
            string? PhoneNumber,
            string? ConcurrencyStamp,
            string? SecurityStamp,
            Gender Gender,
            string FullName,
            string Email,
            bool EmailConfirmed,
            string? NormalizedEmail,
            string? NormalizedUserName,
            string UserName,
            bool LockoutEnabled,
            int AccessFailedCount
        );
}
