using System;
using TaskSystem.BL.Common;
using TaskSystem.DL;
using TaskSystem.DL.Entities.Tasks;

namespace TaskSystem.BL.Services
{
    public class NoteService : ServiceBase
    {
        public NoteService(AppDbContext db) : base(db)
        {
        }

        public int AddNote(string text, int taskId)
        {
            var note = new WorkTaskNote
            {
                DateAdded = DateTime.Now,
                Note = text,
                UserId = UserId,
                WorkTaskId = taskId
            };
            Db.WorkTaskNotes.Add(note);

            return note.Id;
        }
    }
}