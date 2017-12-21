using System;
using System.Collections.Generic;
using System.Text;
using TaskSystem.DL.Entities.Articles;
using TaskSystem.DL.Entities.Tasks;

namespace TaskSystem.DL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        public int Role { get; set; }

        public ICollection<ArticleAttachment> ArticleAttachments { get; set; }
        public ICollection<Document> Documents { get; set; }
        public ICollection<WorkTask> WorkTasks { get; set; }
        public ICollection<WorkTaskNote> WorkTaskNotes { get; set; }
    }
}
