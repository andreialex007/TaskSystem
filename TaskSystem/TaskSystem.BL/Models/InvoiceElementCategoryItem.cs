using System.ComponentModel.DataAnnotations;

namespace TaskSystem.BL.Models
{
    public class InvoiceElementCategoryItem : ViewModelBase
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}