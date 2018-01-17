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
        [Route("delete/{id?}")]
        public IActionResult Delete(int id)
        {
            Service.Invoice.Delete(id);
            return Ok();
        }

    }
}
