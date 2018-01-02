using System;

namespace TaskSystem.BL.Models
{
    public class WorkTaskNoteItem : ViewModelBase
    {
        public int Id { get; set; }

        public string Note { get; set; }

        public int UserId { get; set; }

        public int WorkTaskId { get; set; }

        public DateTime DateAdded { get; set; }
    }
}
