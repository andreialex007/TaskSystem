using System.Collections.Generic;

namespace TaskSystem.DL.Entities.Invoices
{
    public class InvoiceElementCategory : IPkidEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<CommonInvoiceElement> CommonInvoiceElements { get; set; }
        public ICollection<InvoiceElement> InvoiceElements { get; set; }
    }
}
