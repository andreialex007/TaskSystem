using System.ComponentModel.DataAnnotations;

namespace TaskSystem.BL.Models
{
    public class UserItem : ViewModelBase
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }

        [Required]
        public string Password { get; set; }

        public int Role { get; set; }
    }
}