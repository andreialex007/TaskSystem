using System.Collections.Generic;
using System.Linq;
using TaskSystem.BL.Models;
using TaskSystem.DL;
using TaskSystem.DL.Entities;
using TaskSystem.DL.Entities.Invoices;

namespace TaskSystem.BL.Extensions
{
    public static class DataExtensions
    {
        public static void DeleteById<T>(this AppDbContext _db, long id) where T : class, IPkidEntity
        {
            _db.Delete<T>(x => x.Id == id);
            _db.SaveChanges();
        }


        public static List<CommonInvoiceElementItem> AllCommonInvoiceElements(this AppDbContext db)
        {
            var items = db.CommonInvoiceElements
                .Select(x => new CommonInvoiceElementItem
                {
                    Id = x.Id,
                    Description = x.Description,
                    Cost = x.Cost,
                    Category = x.InvoiceElementCategory.Name,
                    InvoiceElementCategoryId = x.InvoiceElementCategoryId
                })
                .ToList();

            return items;
        }

        public static List<InvoiceElementCategoryItem> AllInvoiceElementCategories(this AppDbContext db)
        {
            var items = db.Set<InvoiceElementCategory>()
                .Select(x => new InvoiceElementCategoryItem
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToList();

            return items;
        }

    }
}