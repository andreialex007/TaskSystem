using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Newtonsoft.Json;
using TaskSystem.BL.Common;
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


        public List<CommonInvoiceElementItem> CommonInvoiceElementItems { get; set; } = new List<CommonInvoiceElementItem>();
        public List<InvoiceElementCategoryItem> Categories { get; set; } = new List<InvoiceElementCategoryItem>();

        [JsonConverter(typeof(DictionaryArrayConverter))]
        public Dictionary<int, string> AvaliablePaymentTypes { get; set; } = EnumUtil.ToDictionary<PaymentTypeEnum>();

        public bool Paid
        {
            get
            {
                var totalCost = InvoiceElements.Sum(x => x.Cost * x.Qty);
                var totalPayment = InvoicePayments.Sum(x => x.Amount);
                return totalPayment >= totalCost;
            }
        }
    }

    public class InvoiceSearchItem
    {
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

        public bool Paid => Payments >= Cost;

        public decimal Cost { get; set; }
        public decimal Payments { get; set; }

    }


}
