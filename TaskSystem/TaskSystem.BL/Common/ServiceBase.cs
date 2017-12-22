﻿using System;
using TaskSystem.DL;

namespace TaskSystem.BL.Common
{
    public abstract class ServiceBase
    {
        protected AppDbContext Db;

        protected ServiceBase(AppDbContext db)
        {
            Db = db;
        }
    }
}