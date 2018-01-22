using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskSystem.BL.Common;
using TaskSystem.BL.Extensions;
using TaskSystem.BL.Models;
using TaskSystem.DL;
using TaskSystem.DL.Entities.Invoices;

namespace TaskSystem.BL.Services
{
    public class InvoicePaymentService : ServiceBase
    {
        public InvoicePaymentService(AppDbContext db) : base(db)
        {
        }

        public void Save(InvoicePaymentItem item)
        {
            item.GetValidationErrors().ThrowIfHasErrors();

            var element = item.Id == 0 ? Db.CreateAndAdd<InvoicePayment>() : Db.InvoicePayments.Single(x => x.Id == item.Id);

            element.Amount = item.Amount;
            element.InvoiceId = item.InvoiceId;
            element.PaymentDate = item.PaymentDate.Value;
            element.PaymentType = item.PaymentType;

            Db.SaveChanges();

            item.Id = element.Id;
        }

        public void Delete(int id)
        {
            Db.DeleteById<InvoicePayment>(id);
        }
    }
}
