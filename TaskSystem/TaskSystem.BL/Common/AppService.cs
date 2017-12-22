using System;
using TaskSystem.BL.Services;
using TaskSystem.DL;

namespace TaskSystem.BL.Common
{
    public class AppService : ServiceBase
    {
        public UserService User { get; set; }

        public AppService(AppDbContext db) : base(db)
        {
            User = new UserService(db);
        }

    }
}
