using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskSystem.BL.Common;
using TaskSystem.BL.Extensions;
using TaskSystem.BL.Models;
using TaskSystem.DL;
using TaskSystem.DL.Entities.Customers;

namespace TaskSystem.BL.Services
{
    public class CustomerUserService : ServiceBase
    {
        public CustomerUserService(AppDbContext db) : base(db)
        {
        }

        public CustomerUserItem Edit(int? id = null)
        {
            var item = new CustomerUserItem();

            if (!id.HasValue)
                item = new CustomerUserItem();
            else
                item = Db.CustomerUsers
                    .Select(x => new CustomerUserItem
                    {
                        Id = x.Id,
                        Email = x.Email,
                        Phone = x.Phone,
                        Name = x.Name,
                        Title = x.Title,
                        CustomerId = x.CustomerId,
                    }).Single(x => x.Id == id);

            return item;
        }


        public void Save(CustomerUserItem item)
        {
            item.GetValidationErrors().ThrowIfHasErrors();

            var user = item.Id == 0 ? Db.CreateAndAdd<CustomerUser>() : Db.CustomerUsers.Single(x => x.Id == item.Id);

            user.Email = item.Email;
            user.CustomerId = item.CustomerId;
            user.Name = item.Name;
            user.Title = item.Title;
            user.CustomerId = item.CustomerId;
            user.Phone = item.Phone;

            Db.SaveChanges();

            item.Id = user.Id;
        }

        public List<CustomerUserItem> CustomerUsers(int customerId)
        {
            return Db.Set<CustomerUser>().Where(x => x.CustomerId == customerId)
                .Select(x => new CustomerUserItem
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToList();
        }


        public void Delete(int id)
        {
            Db.DeleteById<CustomerUser>(id);
        }
    }
}
