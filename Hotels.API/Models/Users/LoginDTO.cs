using System.ComponentModel.DataAnnotations;

namespace Hotels.API.Models.Users
{
    public class LoginDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Must have min length of 6 and max Length of 1", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
