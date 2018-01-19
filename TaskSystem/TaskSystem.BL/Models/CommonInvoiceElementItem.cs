using System;
using System.Collections.Generic;
using System.Text;

namespace TaskSystem.BL.Models
{
    public class CommonInvoiceElementItem : ViewModelBase
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }

        public int InvoiceElementCategoryId { get; set; }
        public string Category { get; set; }
    }
}
