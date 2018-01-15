using System;
using System.Collections.Generic;
using System.Linq;
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

        public DocumentItem GetFile(int fileId)
        {
            var doc = Db.Documents.Select(x=> new DocumentItem
            {
                Id = x.Id,
                UserId = x.UserId,
                Name = x.Name,
                WorkTaskId = x.WorkTaskId,
                Path = x.Path
            })
            .Single(x => x.Id == fileId);
            return doc;
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
