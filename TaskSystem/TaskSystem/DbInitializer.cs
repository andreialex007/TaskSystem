using System.Collections.Generic;
using System.Linq;
using TaskSystem.BL.Utils;
using TaskSystem.DL;
using TaskSystem.DL.Entities;
using TaskSystem.DL.Entities.Customers;
using TaskSystem.DL.Entities.Invoices;

namespace TaskSystem
{
    public class DbInitializer
    {
        public static void Initialize(AppDbContext db)
        {
            db.Database.EnsureCreated();//if db is not exist ,it will create database .but ,do nothing .
            InitCustomers(db);
            InitUsers(db);
            InitInvoiceSettings(db);
        }

        public static void InitInvoiceSettings(AppDbContext db)
        {
            if (db.InvoiceElementCategories.Any())
                return;

            var category = new InvoiceElementCategory
            {
                Name = "First",
                CommonInvoiceElements = new List<CommonInvoiceElement>
                {
                    new CommonInvoiceElement
                    {
                        Description = "Common element 1",
                        Cost = 10
                    }   ,
                    new CommonInvoiceElement
                    {
                        Description = "Common element 2",
                        Cost = 50
                    }
                }
            };
            var second = new InvoiceElementCategory
            {
                Name = "First"
            };

            db.InvoiceElementCategories.Add(category);
            db.InvoiceElementCategories.Add(second);
            db.SaveChanges();

            category.CommonInvoiceElements.ToList().ForEach(x=>x.InvoiceElementCategoryId = category.Id);
            db.CommonInvoiceElements.AddRange(category.CommonInvoiceElements);
            db.SaveChanges();
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
                Password = "123456i".ToHash()
            };

            var tech = new User
            {
                FirstName = "Technician",
                LastName = "Technician",
                Email = "Technician@Technician.com",
                Role = 2,
                Password = "123456i".ToHash()
            };

            db.Users.Add(admin);
            db.Users.Add(tech);
            db.SaveChanges();
        }
    }
}
