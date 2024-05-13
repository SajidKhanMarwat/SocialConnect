using Microsoft.AspNetCore.Identity;

namespace SocialConnect.Web.Models.ViewModels
{
    public class RegisterViewModel
    {
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ConcurrencyStamp { get; set; }
        public string? SecurityStamp { get; set; }
        public required string PasswordHash { get; set; }
        public bool EmailConfirmed { get; set; }
        public string? NormalizedEmail { get; set; }
        public required string Email { get; set; }
        public string? NormalizedUserName { get; set; }
        public required string UserName { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        //public required string UserName { get; set; }
        //public string? NormalizedUserName { get; set; }
        //public required string Email { get; set; }
        //public string? NormalizedEmail { get; set; }
        ////public string? EmailConfirmed { get; set; }
        //public required string Password { get; set; }
        //public string? PhoneNumber { get; set; }

    }
}
