using System.Collections.Generic;
using System.Linq;
using TaskSystem.BL.Common;
using TaskSystem.BL.Exceptions;
using TaskSystem.BL.Extensions;
using TaskSystem.BL.Models;
using TaskSystem.BL.Utils;
using TaskSystem.DL;
using TaskSystem.DL.Entities;

namespace TaskSystem.BL.Services
{
    public class UserService : ServiceBase
    {
        public UserService(AppDbContext db) : base(db)
        {
        }

        public User Login(UserItem item)
        {
            var errors = item.GetValidationErrors(x => x.Email, x => x.Password);
            errors.ThrowIfHasErrors();

            var hash = Hasher.HashPassword(item.Password);

            var user = Db.Users.SingleOrDefault(x => x.Email == item.Email && x.Password == hash);
            if (user == null)
                throw new ValidationException("User name or password is invalid");

            return user;
        }

        public User Login(string email, string password)
        {
            return Login(new UserItem { Email = email, Password = password });
        }

        public List<UserItem> All()
        {
            return Db.Users
                .Select(x => new UserItem
                {
                    Id = x.Id,
                    Email = x.Email,
                    Password = x.Password,
                    LastName = x.LastName,
                    Role = x.Role,
                    FirstName = x.FirstName,
                    Phone = x.Phone,
                })
                .ToList();
        }

        public UserItem Edit(int? id = null)
        {
            var user = id.HasValue
                 ? new UserItem()
                 : Db.Users
                     .Select(x => new UserItem
                     {
                         Email = x.Email,
                         Id = x.Id,
                         FirstName = x.FirstName,
                         LastName = x.LastName,
                         Phone = x.Phone,
                         Role = x.Role,
                     })
                     .Single(x => x.Id == id);

            return user;
        }

        public void Save(UserItem item)
        {
            item.GetValidationErrors(
                x => x.Email,
                x => x.FirstName,
                x => x.LastName,
                x => x.Phone,
                x => x.Role
            ).ThrowIfHasErrors();


            var user = item.Id == 0 ? Db.CreateAndAdd<User>() : Db.Users.Single(x => x.Id == item.Id);
            user.Email = item.Email;
            user.FirstName = item.FirstName;
            user.LastName = item.LastName;
            user.Phone = item.Phone;
            user.Role = item.Role;
            Db.SaveChanges();

            item.Id = user.Id;
        }

        public void Delete(int id)
        {
            Db.DeleteById<User>(id);
        }
    }
}