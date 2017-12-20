using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TaskSystem.DL.Entities;
using TaskSystem.DL.Entities.Articles;
using TaskSystem.DL.Entities.Customers;
using TaskSystem.DL.Entities.Invoices;
using TaskSystem.DL.Entities.Tasks;

namespace TaskSystem.DL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleAttachment> ArticleAttachments { get; set; }
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerUser> CustomerUsers { get; set; }
        public DbSet<CommonInvoiceElement> CommonInvoiceElements { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceElement> InvoiceElements { get; set; }
        public DbSet<InvoiceElementCategory> InvoiceElementCategories { get; set; }
        public DbSet<InvoicePayment> InvoicePayments { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<WorkTask> WorkTasks { get; set; }
        public DbSet<WorkTaskNote> WorkTaskNotes { get; set; }
    }
}
