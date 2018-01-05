using System;
using TaskSystem.BL.Common;
using TaskSystem.BL.Extensions;
using TaskSystem.BL.Models;
using TaskSystem.DL;
using TaskSystem.DL.Entities.Tasks;

namespace TaskSystem.BL.Services
{
    public class NoteService : ServiceBase
    {
        public NoteService(AppDbContext db) : base(db)
        {
        }

        public WorkTaskNoteItem AddNote(string text, int taskId)
        {
            var note = new WorkTaskNote
            {
                DateAdded = DateTime.Now,
                Note = text,
                UserId = UserId,
                WorkTaskId = taskId
            };
            Db.WorkTaskNotes.Add(note);
            Db.SaveChanges();

            return new WorkTaskNoteItem
            {
                Id = note.Id,
                UserId = note.UserId,
                WorkTaskId = note.WorkTaskId,
                Note = note.Note,
                UserName = UserFullName,
                DateAdded = note.DateAdded
            };
        }

        public void Delete(int id)
        {
            Db.DeleteById<WorkTaskNote>(id);
        }
    }
}