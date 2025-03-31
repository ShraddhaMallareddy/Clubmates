using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Clubmates.web.Models.AccountViewModel
{
    public class RegisterViewModel 
    {
        [Required(ErrorMessage =("FullName is mandatory"))]
        public string FullName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Email is mandatory")]
        [EmailAddress(ErrorMessage = "This is not valid email, use this format test@test.com")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please provide a password to secure your account")]
        public string Password { get; set; } = string.Empty;
        [Required(ErrorMessage = "This password has to match the previous one")]
        public string ConfirmPassword { get; set; }=string.Empty;
    }
}
