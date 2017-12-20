using System.Collections.Generic;
using TaskSystem.DL.Entities.Invoices;
using TaskSystem.DL.Entities.Tasks;

namespace TaskSystem.DL.Entities.Customers
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Notes { get; set; }

        public ICollection<CustomerUser> CustomerUsers { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<WorkTask> WorkTask { get; set; }
    }
}
