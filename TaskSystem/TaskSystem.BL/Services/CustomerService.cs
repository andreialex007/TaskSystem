using System.Linq;
using TaskSystem.BL.Common;
using TaskSystem.BL.Extensions;
using TaskSystem.BL.Models;
using TaskSystem.DL;

namespace TaskSystem.BL.Services
{
    public class CustomerService : ServiceBase
    {
        public CustomerService(AppDbContext db) : base(db)
        {
        }

        public SearchModel<CustomerItem> Search(string term, string orderBy, bool isAsc, int take, int skip)
        {
            var model = new SearchModel<CustomerItem>();

            var query = Db.Customers
                .Select(x => new CustomerItem
                {
                    Id = x.Id,
                    Phone = x.Phone,
                    Name = x.Name,
                    Address = x.Address,
                    Notes = x.Notes
                });

            if (term.IsNotEmptyOrWhiteSpace())
            {
                query = query.Where(x =>
                    x.Name.ToLower().Contains(term.ToLower()) ||
                    x.Notes.ToLower().Contains(term.ToLower())
                );
            }

            var items = query.OrderBy(orderBy)
                .TakePage(skip, take)
                .ToList();

            model.data = items;
            model.recordsTotal = Db.Customers.Count();
            model.recordsFiltered = query.Count();
            return model;
        }

    }
}
