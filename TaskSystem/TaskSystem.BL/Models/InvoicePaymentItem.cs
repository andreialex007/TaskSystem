using System;

namespace TaskSystem.BL.Models
{
    public class InvoicePaymentItem : ViewModelBase
    {
        public int Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public int PaymentType { get; set; }
        public decimal Amount { get; set; }

        public int InvoiceId { get; set; }
    }
}