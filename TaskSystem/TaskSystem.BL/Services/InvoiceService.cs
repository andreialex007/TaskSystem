using System;
using System.Collections.Generic;
using System.Text;
using TaskSystem.BL.Common;
using TaskSystem.BL.Models;
using TaskSystem.DL;

namespace TaskSystem.BL.Services
{
    public class InvoiceService : ServiceBase
    {
        public InvoiceService(AppDbContext db) : base(db)
        {
        }

        public InvoiceItem New(int taskId)
        {
            var invoiceItem = new InvoiceItem();
            

            return invoiceItem;
        }

    }
}
