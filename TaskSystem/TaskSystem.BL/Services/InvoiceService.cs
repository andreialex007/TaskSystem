﻿using System.Linq;
using Microsoft.EntityFrameworkCore;
using TaskSystem.BL.Common;
using TaskSystem.BL.Extensions;
using TaskSystem.BL.Models;
using TaskSystem.DL;
using TaskSystem.DL.Entities.Invoices;
using TaskSystem.DL.Entities.Tasks;

namespace TaskSystem.BL.Services
{
    public class InvoiceService : ServiceBase
    {
        public InvoiceService(AppDbContext db) : base(db)
        {
        }

        public SearchModel<InvoiceSearchItem> Search(string term, string orderBy, bool isAsc, int take, int skip)
        {
            var model = new SearchModel<InvoiceSearchItem>();

            var query = Db.Invoices
                .Select(x => new InvoiceSearchItem
                {
                    Id = x.Id,
                    Remarks = x.Remarks,
                    TaskName = x.WorkTask.Description,
                    Cost = x.InvoiceElements.Sum(e => e.Cost * e.Qty),
                    Payments = x.InvoicePayments.Sum(p => p.Amount),
                    CustomerName = x.WorkTask.Customer.Name,
                    CustomerUserName = x.WorkTask.CustomerUser.Name,
                    Created = x.Created
                });

            if (term.IsNotEmptyOrWhiteSpace())
            {
                query = query.Where(x =>
                    x.Remarks.ToLower().Contains(term.ToLower()) ||
                    x.TaskName.ToLower().Contains(term.ToLower()) ||
                    x.CustomerName.ToLower().Contains(term.ToLower()) ||
                    x.CustomerUserName.ToLower().Contains(term.ToLower())
                );
            }

            var items = query.OrderBy(orderBy, isAsc)
                .TakePage(skip, take)
                .ToList();

            model.data = items;
            model.recordsTotal = Db.Set<Invoice>().Count();
            model.recordsFiltered = query.Count();

            return model;
        }

        public InvoiceItem New(int taskId)
        {
            var invoiceItem = new InvoiceItem();

            var task = Db.Set<WorkTask>()
                .Include(x => x.Customer)
                .Include(x => x.CustomerUser)
                .Single(x => x.Id == taskId);

            invoiceItem.CustomerName = task.Customer.Name;
            invoiceItem.CustomerUserName = task.CustomerUser.Name;
            invoiceItem.TaskName = task.Name;
            invoiceItem.TaskId = taskId;

            return invoiceItem;
        }

        public InvoiceItem Get(int invoiceId)
        {
            var item = Db.Set<Invoice>()
                .Select(x => new InvoiceItem
                {
                    Id = x.Id,
                    TaskName = x.WorkTask.Name,
                    TaskId = x.WorkTask.Id,
                    Remarks = x.Remarks,
                    CustomerName = x.WorkTask.Customer.Name,
                    CustomerUserName = x.WorkTask.CustomerUser.Name,
                    CustomerId = x.WorkTask.CustomerId,
                    InvoiceElements = x.InvoiceElements
                        .Select(i => new InvoiceElementItem
                        {
                            Id = i.Id,
                            Description = i.Description,
                            Cost = i.Cost,
                            Qty = i.Qty,
                            InvoiceElementCategoryId = i.InvoiceElementCategoryId,
                            CategoryName = i.InvoiceElementCategory.Name,
                            InvoiceId = i.InvoiceId
                        })
                        .ToList(),
                    InvoicePayments = x.InvoicePayments
                        .Select(p => new InvoicePaymentItem
                        {
                            Id = p.Id,
                            InvoiceId = p.InvoiceId,
                            Amount = p.Amount,
                            PaymentDate = p.PaymentDate,
                            PaymentType = p.PaymentType
                        })
                        .ToList()
                })
                .Single(x => x.Id == invoiceId);

            item.Categories = Db.AllInvoiceElementCategories();
            item.CommonInvoiceElementItems = Db.AllCommonInvoiceElements();

            return item;
        }

        public void Save(InvoiceItem item)
        {
            item.GetValidationErrors().ThrowIfHasErrors();

            var invoice = item.Id == 0 ? Db.CreateAndAdd<Invoice>() : Db.Set<Invoice>().Single(x => x.Id == item.Id);
            invoice.WorkTaskId = item.TaskId;
            invoice.Remarks = item.Remarks;
            invoice.Created = item.Created;

            Db.SaveChanges();

            item.Id = invoice.Id;
        }

        public void Delete(int id)
        {
            var invoice = Db.Invoices
                .Include(x => x.InvoiceElements)
                .Include(x => x.InvoicePayments)
                .Single(x => x.Id == id);

            Db.InvoicePayments.RemoveRange(invoice.InvoicePayments);
            Db.InvoiceElements.RemoveRange(invoice.InvoiceElements);
            Db.Invoices.Remove(invoice);
            Db.SaveChanges();
        }
    }
}