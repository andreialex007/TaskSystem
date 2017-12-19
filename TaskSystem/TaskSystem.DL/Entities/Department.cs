using System.Collections.Generic;

namespace TaskSystem.DL.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Address { get; set; }

        public ICollection<User> Users { get; set; }

    }
}