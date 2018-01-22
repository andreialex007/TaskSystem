using System;
using System.ComponentModel.DataAnnotations;
using TaskSystem.BL.Extensions;
using TaskSystem.BL.Utils;

namespace TaskSystem.BL.Models
{
    public class InvoicePaymentItem : ViewModelBase
    {

        public InvoicePaymentItem()
        {
            PaymentDate = DateTime.Now;
        }

        public int Id { get; set; }

        [Required]
        public DateTime? PaymentDate { get; set; }

        [Range(1, 4, ErrorMessage = "Valid payment type required")]
        public int PaymentType { get; set; }

        public string PaymentTypeName =>  this.PaymentType == 0 ? "" : PaymentType.CastTo<PaymentTypeEnum>().DescriptionAttr();     
        public PaymentTypeEnum? PaymentTypeEnum => this.PaymentType == 0 ? new PaymentTypeEnum?() : PaymentType.CastTo<PaymentTypeEnum>();     

        [Range(1, int.MaxValue, ErrorMessage = "Amount required")]
        public decimal Amount { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Invoice required")]
        public int InvoiceId { get; set; }
    }
}