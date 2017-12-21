using System.Linq;
using TaskSystem.BL.Utils;
using TaskSystem.DL;
using TaskSystem.DL.Entities;

namespace TaskSystem
{
    public class DbInitializer
    {
        public static void Initialize(AppDbContext db)
        {
            db.Database.EnsureCreated();//if db is not exist ,it will create database .but ,do nothing .

            // Look for any students.
            if (db.Users.Any())
                return; // DB has been seeded

            var admin = new User
            {
                FirstName = "Admin",
                LastName = "Admin",
                Email = "admin@admin.com",
                Role = 1,
                Password = Hasher.HashPassword("123456i")
            };

            db.Users.Add(admin);
            db.SaveChanges();
        }
    }
}
