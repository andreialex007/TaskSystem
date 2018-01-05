using System;
using System.Collections.Generic;
using System.Text;
using TaskSystem.BL.Common;
using TaskSystem.BL.Models;
using TaskSystem.DL;
using TaskSystem.DL.Entities.Tasks;

namespace TaskSystem.BL.Services
{
    public class DocumentService : ServiceBase
    {
        public DocumentService(AppDbContext db) : base(db)
        {
        }

        public DocumentItem AddFile(string path, int taskId)
        {
            var document = new Document
            {
                Name = System.IO.Path.GetFileName(path),
                UserId = UserId,
                Path = path,
                WorkTaskId = taskId
            };

            Db.Documents.Add(document);
            Db.SaveChanges();

            return new DocumentItem
            {
                Id = document.Id,
                Name = document.Name,
                UserId = document.UserId,
                UserName = UserFullName,
                WorkTaskId = document.WorkTaskId,
                Path = path,
            };
        }
    }
}
