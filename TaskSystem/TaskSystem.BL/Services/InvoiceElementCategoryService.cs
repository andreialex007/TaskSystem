using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TaskSystem.BL.Common;
using TaskSystem.BL.Extensions;
using TaskSystem.BL.Models;
using TaskSystem.DL;
using TaskSystem.DL.Entities.Invoices;

namespace TaskSystem.BL.Services
{
    public class InvoiceElementCategoryService : ServiceBase
    {
        public InvoiceElementCategoryService(AppDbContext db) : base(db)
        {
        }

        public List<InvoiceElementCategoryItem> All()
        {
            return Db.AllInvoiceElementCategories();
        }

        public InvoiceElementCategoryItem Edit(int id)
        {
            var model = new InvoiceElementCategoryItem();
            if (id != 0)
                model = Db.Set<InvoiceElementCategory>()
                    .Select(x => new InvoiceElementCategoryItem
                    {
                        Id = x.Id,
                        Name = x.Name
                    })
                    .Single(x => x.Id == id);
            return model;
        }

        public void Save(InvoiceElementCategoryItem item)
        {
            item.GetValidationErrors().ThrowIfHasErrors();

            var category = item.Id == 0
                ? Db.CreateAndAdd<InvoiceElementCategory>()
                : Db.Set<InvoiceElementCategory>().Single(x => x.Id == item.Id);

            category.Name = item.Name;
            Db.SaveChanges();
            item.Id = category.Id;
        }

        public void Delete(int id)
        {
            var category = Db.Set<InvoiceElementCategory>()
                .Include(x => x.CommonInvoiceElements)
                .Include(x => x.InvoiceElements)
                .Single(x => x.Id == id);

            Db.Set<CommonInvoiceElement>().RemoveRange(category.CommonInvoiceElements);
            Db.Set<InvoiceElement>().RemoveRange(category.InvoiceElements);
            Db.Set<InvoiceElementCategory>().Remove(category);
            Db.SaveChanges();
        }
    }
}