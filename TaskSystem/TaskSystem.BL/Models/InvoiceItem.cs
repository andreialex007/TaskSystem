using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using TaskSystem.BL.Common;
using TaskSystem.BL.Extensions;
using TaskSystem.BL.Utils;

namespace TaskSystem.BL.Models
{
    public class InvoiceItem : ViewModelBase
    {
        public InvoiceItem()
        {
            Created = DateTime.Now;
        }

        public int Id { get; set; }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerUserName { get; set; }
        public string TaskName { get; set; }

        [Required]
        public int? TaskId { get; set; }
        public int Status { get; set; }

        [Required]
        public string Remarks { get; set; }
        public DateTime Created { get; set; }

        public ICollection<InvoiceElementItem> InvoiceElements { get; set; } = new List<InvoiceElementItem>();
        public ICollection<InvoicePaymentItem> InvoicePayments { get; set; } = new List<InvoicePaymentItem>();

    }
}
