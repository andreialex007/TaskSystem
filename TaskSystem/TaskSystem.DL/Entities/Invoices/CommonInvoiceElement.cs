namespace TaskSystem.DL.Entities.Invoices
{
    public class CommonInvoiceElement : IPkidEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }

        public int InvoiceElementCategoryId { get; set; }
        public InvoiceElementCategory InvoiceElementCategory { get; set; }
    }
}
