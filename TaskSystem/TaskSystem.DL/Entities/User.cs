using System;
using System.Text;

namespace TaskSystem.DL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public int PositionId { get; set; }
        public Position Position { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
