using System.Collections.Generic;
using System.Linq;
using TaskSystem.BL.Common;
using TaskSystem.BL.Extensions;
using TaskSystem.BL.Models;
using TaskSystem.DL;
using TaskSystem.DL.Entities;
using TaskSystem.DL.Entities.Tasks;

namespace TaskSystem.BL.Services
{
    public class WorkTaskService : ServiceBase
    {
        public WorkTaskService(AppDbContext db) : base(db)
        {
        }

        public SearchModel<WorkTaskItem> Search(string term, string orderBy, bool isAsc, int take, int skip)
        {
            var model = new SearchModel<WorkTaskItem>();

            var query = Db.WorkTasks
                .Select(x => new WorkTaskItem
                {
                    Id = x.Id,
                    Name = x.Name,
                    CustomerId = x.CustomerId,
                    CustomerUserId = x.CustomerUserId,
                    Priority = x.Priority,
                    Status = x.Status,
                    UserId = x.UserId
                });

            if (term.IsNotEmptyOrWhiteSpace())
            {
                query = query.Where(x =>
                    x.Name.ToLower().Contains(term.ToLower())
                );
            }

            var items = query.OrderBy(orderBy)
                .TakePage(skip, take)
                .ToList();

            model.data = items;
            model.recordsTotal = Db.Set<WorkTask>().Count();
            model.recordsFiltered = query.Count();

            return model;
        }

        public WorkTaskItem Edit(int? id = null)
        {
            var customer = !id.HasValue
                ? new WorkTaskItem()
                : Db.WorkTasks
                    .Select(x => new WorkTaskItem
                    {
                        Id = x.Id,
                        Name = x.Name,
                        CustomerId = x.CustomerId,
                        Status = x.Status,
                        Description = x.Description,
                        Priority = x.Priority,
                        UserId = x.UserId,
                        CustomerUserId = x.CustomerUserId,
                        AvaliableCustomers = new List<AutocompleteItem>
                        {
                            new AutocompleteItem
                            {
                                Id = x.CustomerId,
                                Text = x.Customer.Name
                            }
                        },
                        AvaliableCustomerUsers = new List<AutocompleteItem>
                        {
                            new AutocompleteItem
                            {
                                Id = x.CustomerUserId ?? 0,
                                Text = x.CustomerUser.Name
                            }
                        },
                        WorkTaskNoteItems = x.WorkTaskNotes
                            .Select(n => new WorkTaskNoteItem
                            {
                                Id = n.Id,
                                UserId = n.UserId,
                                UserName = n.User.FirstName + " " + n.User.LastName,
                                WorkTaskId = n.WorkTaskId,
                                Note = n.Note,
                                DateAdded = n.DateAdded
                            }).ToList()
                    })
                    .Single(x => x.Id == id);

            var role = RoleEnum.Technician.CastTo<int>();
            customer.AvaliableUsers = Db.Set<User>()
                .Where(x => x.Role == role)
                .Select(x => new AutocompleteItem
                {
                    Id = x.Id,
                    Text = x.FirstName + " " + x.LastName
                })
                .ToList();

            return customer;
        }


        public void Save(WorkTaskItem item)
        {
            item.GetValidationErrors().ThrowIfHasErrors();

            var customer = item.Id == 0 ? Db.CreateAndAdd<WorkTask>() : Db.Set<WorkTask>().Single(x => x.Id == item.Id);

            customer.Name = item.Name;
            customer.Priority = item.Priority;
            customer.Status = item.Status;
            customer.CustomerId = item.CustomerId ?? 0;
            customer.CustomerUserId = item.CustomerUserId;
            customer.Description = item.Description;
            customer.UserId = item.UserId ?? 0;

            Db.SaveChanges();
            item.Id = customer.Id;
        }

        public void Delete(int id)
        {
            Db.DeleteById<WorkTask>(id);
        }

    }
}
