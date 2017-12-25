using System.ComponentModel.DataAnnotations;

namespace TaskSystem.BL.Models
{
    public class UserLoginItem  : ViewModelBase
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}