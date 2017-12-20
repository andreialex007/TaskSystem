using System.Collections.Generic;
using TaskSystem.DL.Entities.Tasks;

namespace TaskSystem.DL.Entities.Customers
{
    public class CustomerUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public ICollection<WorkTask> WorkTasks { get; set; }
    }
}