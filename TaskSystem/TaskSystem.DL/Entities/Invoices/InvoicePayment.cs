using System;

namespace TaskSystem.DL.Entities.Invoices
{
    public class InvoicePayment
    {
        public int Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public int PaymentType { get; set; }
        public decimal Amount { get; set; }

        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
    }
}
