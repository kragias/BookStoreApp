using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.Api.Models.User
{
    public class LoginUserDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } //same with usernanme so i dont want them both

        [Required]
        public string Password { get; set; }
    }
}
