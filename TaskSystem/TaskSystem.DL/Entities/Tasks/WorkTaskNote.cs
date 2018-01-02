using System;

namespace TaskSystem.DL.Entities.Tasks
{
    public class WorkTaskNote : IPkidEntity
    {
        public int Id { get; set; }

        public string Note { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int? WorkTaskId { get; set; }
        public WorkTask WorkTask { get; set; }

        public DateTime DateAdded { get; set; }
    }
}
