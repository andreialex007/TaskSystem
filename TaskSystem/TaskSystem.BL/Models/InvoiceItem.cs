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
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public int TaskId { get; set; }
        public int Status { get; set; }

        public ICollection<InvoiceElementItem> InvoiceElements { get; set; } = new List<InvoiceElementItem>();
        public ICollection<InvoicePaymentItem> InvoicePayments { get; set; } = new List<InvoicePaymentItem>();

    }
}
