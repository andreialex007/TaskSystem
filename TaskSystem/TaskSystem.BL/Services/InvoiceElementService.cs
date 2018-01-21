using System.Linq;
using TaskSystem.BL.Common;
using TaskSystem.BL.Extensions;
using TaskSystem.BL.Models;
using TaskSystem.DL;
using TaskSystem.DL.Entities.Invoices;

namespace TaskSystem.BL.Services
{
    public class InvoiceElementService : ServiceBase
    {
        public InvoiceElementService(AppDbContext db) : base(db)
        {
        }

        public void Save(InvoiceElementItem item)
        {
            item.GetValidationErrors().ThrowIfHasErrors();

            var element = item.Id == 0 ? Db.CreateAndAdd<InvoiceElement>() : Db.InvoiceElements.Single(x => x.Id == item.Id);

            element.Cost = item.Cost;
            element.Description = item.Description;
            element.InvoiceElementCategoryId = item.InvoiceElementCategoryId;
            element.InvoiceId = item.InvoiceId;
            element.Qty = item.Qty;

            Db.SaveChanges();

            item.CategoryName = Db.InvoiceElementCategories.Single(x => x.Id == item.InvoiceElementCategoryId).Name;
            item.Id = element.Id;
        }

        public void Delete(int id)
        {
            Db.DeleteById<InvoiceElement>(id);
        }
    }
}
