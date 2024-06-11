using Microsoft.AspNetCore.Identity;
using SocialConnect.Web.Models.ModelEnums;
using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "Gender is required.")]
        public Gender Gender { get; set; }
        [Required(ErrorMessage = "Enter your full name.")]
        public string FullName {  get; set; }

        [Required(ErrorMessage = "Password hash is required.")]
        public string PasswordHash { get; set; }

        [Required(ErrorMessage = "Confirmation password is required.")]
        [Compare("PasswordHash", ErrorMessage = "Passwords must match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email.")]
        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }
        public string? NormalizedEmail { get; set; }
        public string? NormalizedUserName { get; set; }

        [Required(ErrorMessage = "Username is required. It will be used to login to your account.")]
        public string UserName { get; set; }

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
