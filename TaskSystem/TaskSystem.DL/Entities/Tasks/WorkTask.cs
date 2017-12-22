using System.Collections.Generic;
using TaskSystem.DL.Entities.Customers;
using TaskSystem.DL.Entities.Invoices;

namespace TaskSystem.DL.Entities.Tasks
{
    public class WorkTask : IPkidEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public int Priority { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int? CustomerUserId { get; set; }
        public CustomerUser CustomerUser { get; set; }

        public ICollection<Document> Documents { get; set; }
        public ICollection<WorkTaskNote> WorkTaskNotes { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}
