using System.Collections.Generic;
using TaskSystem.DL.Entities.Customers;

namespace TaskSystem.DL.Entities.Invoices
{
    public class Invoice : IPkidEntity
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int TaskId { get; set; }
        public int Status { get; set; }

        public ICollection<InvoiceElement> InvoiceElements { get; set; }
        public ICollection<InvoicePayment> InvoicePayments { get; set; }

    }
}
