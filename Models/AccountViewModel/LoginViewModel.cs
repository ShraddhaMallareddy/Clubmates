using System.ComponentModel.DataAnnotations;

namespace Clubmates.web.Models.AccountViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "User name is mandatory")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "password is mandatory")]
        public string Password { get; set; } = string.Empty;

    }
}
