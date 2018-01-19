using System.Collections.Generic;
using System.Linq;
using TaskSystem.BL.Common;
using TaskSystem.BL.Extensions;
using TaskSystem.BL.Models;
using TaskSystem.DL;
using TaskSystem.DL.Entities.Invoices;

namespace TaskSystem.BL.Services
{
    public class CommonInvoiceElementService : ServiceBase
    {
        public CommonInvoiceElementService(AppDbContext db) : base(db)
        {
        }

        public List<CommonInvoiceElementItem> All()
        {
            var items = Db.CommonInvoiceElements
                .Select(x => new CommonInvoiceElementItem
                {
                    Id = x.Id,
                    Description = x.Description,
                    Cost = x.Cost,
                    Category = x.InvoiceElementCategory.Name
                })
                .ToList();

            return items;
        }

        public CommonInvoiceElementItem Edit(int id)
        {
            var item = new CommonInvoiceElementItem();

            if (id != 0)
            {
                item = Db.Set<CommonInvoiceElement>()
                    .Select(x => new CommonInvoiceElementItem
                    {
                        Id = x.Id,
                        Description = x.Description,
                        Cost = x.Cost,
                        Category = x.InvoiceElementCategory.Name
                    })
                    .Single(x => x.Id == id);
            }

            return item;
        }

        public void Save(CommonInvoiceElementItem item)
        {
            item.GetValidationErrors().ThrowIfHasErrors();

            var commonInvoiceElement = item.Id == 0
                ? Db.CreateAndAdd<CommonInvoiceElement>()
                : Db.Set<CommonInvoiceElement>().Single(x => x.Id == item.Id);

            commonInvoiceElement.Cost = item.Cost;
            commonInvoiceElement.Description = item.Description;

            Db.SaveChanges();
            item.Id = commonInvoiceElement.Id;
        }


        public void Delete(int id)
        {
            Db.DeleteById<CommonInvoiceElement>(id);
        }
    }
}
