﻿using TaskSystem.BL.Services;
using TaskSystem.DL;

namespace TaskSystem.BL.Common
{
    public class AppService : ServiceBase
    {
        public AppService(AppDbContext db) : base(db)
        {
            User = new UserService(db);
            Customer = new CustomerService(db);
            CustomerUser = new CustomerUserService(db);
            WorkTask = new WorkTaskService(db);
            Note = new NoteService(db);
            Document = new DocumentService(db);
        }

        public UserService User { get; set; }
        public CustomerService Customer { get; set; }
        public CustomerUserService CustomerUser { get; set; }
        public WorkTaskService WorkTask { get; set; }
        public NoteService Note { get; set; }
        public DocumentService Document { get; set; }
    }
}