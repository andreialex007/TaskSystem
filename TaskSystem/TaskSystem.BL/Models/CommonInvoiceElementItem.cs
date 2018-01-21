using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TaskSystem.BL.Models
{
    public class CommonInvoiceElementItem : ViewModelBase
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Cost must be greater than zero")]
        public decimal Cost { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please select category")]
        public int InvoiceElementCategoryId { get; set; }
        public string Category { get; set; }
    }
}
