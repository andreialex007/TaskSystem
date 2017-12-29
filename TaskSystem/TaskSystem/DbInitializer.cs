using System.Linq;
using TaskSystem.BL.Utils;
using TaskSystem.DL;
using TaskSystem.DL.Entities;
using TaskSystem.DL.Entities.Customers;

namespace TaskSystem
{
    public class DbInitializer
    {
        public static void Initialize(AppDbContext db)
        {
            db.Database.EnsureCreated();//if db is not exist ,it will create database .but ,do nothing .
            InitCustomers(db);
            InitUsers(db);
        }

        private static void InitCustomers(AppDbContext db)
        {
            if (db.Customers.Any())
                return;

            var customer = new Customer
            {
                Name = "Test customer",
                Phone = "3453463463",
                Address = "test address"
            };

            db.Customers.Add(customer);

            var user = new CustomerUser
            {
                Email = "tets@email.com",
                Name = "First customer user",
                Phone = "345345345",
                Title = "Editor",
                Customer = customer
            };

            db.CustomerUsers.Add(user);
            customer.CustomerUsers.Add(user);
            db.SaveChanges();
        }

        private static void InitUsers(AppDbContext db)
        {
            // Look for any students.
            if (db.Users.Any())
                return;

            var admin = new User
            {
                FirstName = "Admin",
                LastName = "Admin",
                Email = "admin@admin.com",
                Role = 1,
                Password = Hasher.HashPassword("123456i")
            };

            var tech = new User
            {
                FirstName = "Technician",
                LastName = "Technician",
                Email = "Technician@Technician.com",
                Role = 2,
                Password = Hasher.HashPassword("123456i")
            };

            db.Users.Add(admin);
            db.Users.Add(tech);
            db.SaveChanges();
        }
    }
}
