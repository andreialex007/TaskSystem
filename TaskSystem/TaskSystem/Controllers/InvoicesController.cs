using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TaskSystem.BL.Models;
using TaskSystem.DL;
using ControllerBase = TaskSystem.Controllers._Common.ControllerBase;

namespace TaskSystem.Controllers
{
    public class InvoicesController : ControllerBase
    {
        public InvoicesController(IConfiguration configuration, AppDbContext appDbContext, IHostingEnvironment hostingEnvironment)
            : base(configuration, appDbContext, hostingEnvironment)
        {
        }

        [HttpPost]
        [Route("task{taskId}/add")]
        public IActionResult Add(int taskId)
        {
            var invoice = Service.Invoice.New(taskId);
            return Ok(invoice);
        }

        [HttpPost]
        [Route("{id?}")]
        public IActionResult Get(int id)
        {
            var item = Service.Invoice.Get(id);
            return Ok(item);
        }

        [HttpPost]
        [Route("save")]
        public IActionResult SaveInvoice([FromBody] InvoiceItem item)
        {
            Service.Invoice.Save(item);
            return Ok(item);
        }

        [HttpPost]
        [Route("saveelement")]
        public IActionResult SaveElement([FromBody] InvoiceElementItem item)
        {
            Service.InvoiceElement.Save(item);
            return Ok(item);
        }

        [HttpPost]
        [Route("savepayment")]
        public IActionResult SavePayment([FromBody] InvoicePaymentItem item)
        {
            Service.InvoicePayment.Save(item);
            return Ok(item);
        }

        [HttpPost]
        [Route("delete/{id?}")]
        public IActionResult Delete(int id)
        {
            Service.Invoice.Delete(id);
            return Ok();
        }


        [HttpPost]
        [Route("deleteitem/{id?}")]
        public IActionResult DeleteItem(int id)
        {
            Service.InvoiceElement.Delete(id);
            return Ok();
        }

        [HttpPost]
        [Route("deletepayment/{id?}")]
        public IActionResult DeletePayment(int id)
        {
            Service.InvoicePayment.Delete(id);
            return Ok();
        }

        [HttpPost]
        [Route("Search")]
        public IActionResult Search(string term, string orderBy, bool isAsc = true, int take = 10, int skip = 0)
        {
            var model = Service.Invoice.Search(term, orderBy, isAsc, take, skip);
            return Ok(model);
        }


    }
}
