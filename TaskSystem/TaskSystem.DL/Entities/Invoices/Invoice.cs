using System;
using System.Collections.Generic;
using TaskSystem.DL.Entities.Customers;
using TaskSystem.DL.Entities.Tasks;

namespace TaskSystem.DL.Entities.Invoices
{
    public class Invoice : IPkidEntity
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int Status { get; set; }

        public int? WorkTaskId { get; set; }
        public WorkTask WorkTask { get; set; }

        public string Remarks { get; set; }
        public DateTime Created { get; set; }

        public ICollection<InvoiceElement> InvoiceElements { get; set; }
        public ICollection<InvoicePayment> InvoicePayments { get; set; }

    }
}
