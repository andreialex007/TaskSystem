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
            var errors = item.GetValidationErrors();
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
    }
}