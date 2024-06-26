﻿namespace SocialConnect.Web.Models.ViewModels
{
    public class LoginViewModel
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public bool RememberMe { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
