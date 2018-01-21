using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TaskSystem.BL.Models;
using TaskSystem.DL;
using TaskSystem.DL.Entities.Invoices;
using ControllerBase = TaskSystem.Controllers._Common.ControllerBase;

namespace TaskSystem.Controllers
{
    public class InvoiceSettingsController : ControllerBase
    {
        public InvoiceSettingsController(IConfiguration configuration, AppDbContext appDbContext, IHostingEnvironment hostingEnvironment)
            : base(configuration, appDbContext, hostingEnvironment)
        {
        }

        [HttpPost]
        [Route("InvoiceElementCategories")]
        public IActionResult InvoiceElementCategories()
        {
            var items = Service.InvoiceElementCategory.All();
            return Ok(items);
        }

        [HttpPost]
        [Route("CommonInvoiceElements")]
        public IActionResult CommonInvoiceElements()
        {
            var items = Service.CommonInvoiceElement.All();
            return Ok(items);
        }

        [HttpPost]
        [Route("Settings")]
        public IActionResult Settings()
        {
            var elements = Service.CommonInvoiceElement.All();
            var categories = Service.InvoiceElementCategory.All();
            return Ok(new
            {
                elements,
                categories
            });
        }

        [HttpPost]
        [Route("SaveCommonInvoiceElement")]
        public IActionResult SaveCommonInvoiceElement([FromBody] CommonInvoiceElementItem item)
        {
            Service.CommonInvoiceElement.Save(item);
            return Ok(item);
        }

        [HttpPost]
        [Route("SaveInvoiceElementCategory")]
        public IActionResult SaveInvoiceElementCategory([FromBody] InvoiceElementCategoryItem item)
        {
            Service.InvoiceElementCategory.Save(item);
            return Ok(item);
        }

        [HttpPost]
        [Route("DeleteCommonInvoiceElement/{id?}")]
        public IActionResult DeleteCommonInvoiceElement(int id)
        {
            Service.CommonInvoiceElement.Delete(id);
            return Ok();
        }
        [HttpPost]
        [Route("DeleteInvoiceElementCategory/{id?}")]
        public IActionResult DeleteInvoiceElementCategory(int id)
        {
            Service.InvoiceElementCategory.Delete(id);
            return Ok();
        }
    }
}
