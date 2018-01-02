using System.Collections.Generic;
using System.Linq;
using TaskSystem.BL.Common;
using TaskSystem.BL.Extensions;
using TaskSystem.BL.Models;
using TaskSystem.DL;
using TaskSystem.DL.Entities.Customers;

namespace TaskSystem.BL.Services
{
    public class CustomerService : ServiceBase
    {
        public CustomerService(AppDbContext db) : base(db)
        {
        }

        public List<AutocompleteItem> Autocomplete(string term)
        {
            return this.Search(term, "Id").data.Select(x => new AutocompleteItem { Id = x.Id, Text = x.Name }).ToList();
        }

        public SearchModel<CustomerItem> Search(string term, string orderBy, bool isAsc = true, int take = 10, int skip = 0)
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


        public CustomerItem Edit(int? id = null)
        {
            var customer = !id.HasValue
                ? new CustomerItem()
                : Db.Customers
                    .Select(x => new CustomerItem
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Phone = x.Phone,
                        Address = x.Address,
                        Notes = x.Notes,
                        Users = x.CustomerUsers
                            .Select(u => new CustomerUserItem
                            {
                                Id = u.Id,
                                Email = u.Email,
                                Phone = u.Phone,
                                Name = u.Name,
                                Title = u.Title
                            })
                            .ToList()
                    })
                    .Single(x => x.Id == id);

            return customer;
        }


        public void Save(CustomerItem item)
        {
            item.GetValidationErrors().ThrowIfHasErrors();

            var customer = item.Id == 0 ? Db.CreateAndAdd<Customer>() : Db.Customers.Single(x => x.Id == item.Id);

            customer.Address = item.Address;
            customer.Name = item.Name;
            customer.Notes = item.Notes;
            customer.Phone = item.Phone;

            Db.SaveChanges();
            item.Id = customer.Id;
        }


        public void Delete(int id)
        {
            Db.DeleteById<Customer>(id);
        }
    }
}
