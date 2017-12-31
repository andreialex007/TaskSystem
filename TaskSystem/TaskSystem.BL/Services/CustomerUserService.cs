using System;
using System.Collections.Generic;
using System.Text;
using TaskSystem.BL.Common;
using TaskSystem.DL;

namespace TaskSystem.BL.Services
{
    public class CustomerUserService : ServiceBase
    {
        public CustomerUserService(AppDbContext db) : base(db)
        {
        }
    }
}
