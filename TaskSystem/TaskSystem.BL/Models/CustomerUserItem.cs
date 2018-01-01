using System.ComponentModel.DataAnnotations;

namespace TaskSystem.BL.Models
{
    public class CustomerUserItem : ViewModelBase
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public int CustomerId { get; set; }
    }
}