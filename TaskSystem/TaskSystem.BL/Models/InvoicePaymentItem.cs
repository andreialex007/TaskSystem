using System;
using System.ComponentModel.DataAnnotations;

namespace TaskSystem.BL.Models
{
    public class InvoicePaymentItem : ViewModelBase
    {
        public int Id { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Payment type required")]
        public int PaymentType { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Amount required")]
        public decimal Amount { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Invoice required")]
        public int InvoiceId { get; set; }
    }
}