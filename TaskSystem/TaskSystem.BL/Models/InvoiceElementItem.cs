namespace TaskSystem.BL.Models
{
    public class InvoiceElementItem : ViewModelBase
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Qty { get; set; }
        public decimal Cost { get; set; }

        public int InvoiceId { get; set; }

        public int InvoiceElementCategoryId { get; set; }
    }
}