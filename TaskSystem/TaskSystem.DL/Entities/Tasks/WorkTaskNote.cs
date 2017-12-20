using System;

namespace TaskSystem.DL.Entities.Tasks
{
    public class WorkTaskNote
    {
        public int Id { get; set; }

        public string Note { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public DateTime DateAdded { get; set; }
    }
}
