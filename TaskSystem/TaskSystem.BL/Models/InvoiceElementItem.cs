using System.ComponentModel.DataAnnotations;

namespace TaskSystem.BL.Models
{
    public class InvoiceElementItem : ViewModelBase
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }


        [Range(1, int.MaxValue, ErrorMessage = "Quantity required")]
        public decimal Qty { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Cost required")]
        public decimal Cost { get; set; }


        [Range(1, int.MaxValue, ErrorMessage = "Invoice required")]
        public int InvoiceId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Category required")]
        public int InvoiceElementCategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}