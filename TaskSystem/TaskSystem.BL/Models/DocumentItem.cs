using System;
using System.Collections.Generic;
using System.Text;
using TaskSystem.BL.Utils;

namespace TaskSystem.BL.Models
{
    public class DocumentItem
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }

        public int? UserId { get; set; }
        public string UserName { get; set; }

        public int WorkTaskId { get; set; }

        public DateTime UploadedDate { get; set; }

        public string Hash { get; set; }
    }
}
