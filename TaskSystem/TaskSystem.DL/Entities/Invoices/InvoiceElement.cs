namespace TaskSystem.DL.Entities.Invoices
{
    public class InvoiceElement : IPkidEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Qty { get; set; }
        public decimal Cost { get; set; }

        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        public int InvoiceElementCategoryId { get; set; }
        public InvoiceElementCategory InvoiceElementCategory { get; set; }
    }
}
