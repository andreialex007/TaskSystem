using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TaskSystem.BL.Models;
using TaskSystem.DL;
using ControllerBase = TaskSystem.Controllers._Common.ControllerBase;

namespace TaskSystem.Controllers
{
    public class CustomersController : ControllerBase
    {
        public CustomersController(IConfiguration configuration, AppDbContext appDbContext, IHostingEnvironment environment) 
            : base(configuration, appDbContext, environment)
        {
        }

        [HttpPost]
        [Route("Search")]
        public IActionResult Search(string term, string orderBy, bool isAsc = true, int take = 10, int skip = 0)
        {
            var model = Service.Customer.Search(term, orderBy, isAsc, take, skip);
            return Ok(model);
        }

        [HttpPost]
        [Route("edit/{id?}")]
        public IActionResult Edit(int? id = null)
        {
            var item = Service.Customer.Edit(id);
            return Ok(item);
        }

        [HttpPost]
        [Route("save")]
        public IActionResult Save([FromBody] CustomerItem item)
        {
            Service.Customer.Save(item);
            return Ok(item);
        }

        [HttpPost]
        [Route("delete/{id?}")]
        public IActionResult Delete(int id)
        {
            Service.Customer.Delete(id);
            return Ok();
        }

        [HttpPost]
        [Route("savecustomeruser")]
        public IActionResult SaveCustomerUser([FromBody] CustomerUserItem item)
        {
            Service.CustomerUser.Save(item);
            return Ok(item);
        }

        [HttpPost]
        [Route("editcustomeruser/{id?}")]
        public IActionResult EditCustomerUser(int? id = null)
        {
            var item = Service.CustomerUser.Edit(id);
            return Ok(item);
        }

        [HttpPost]
        [Route("deletecustomeruser/{id?}")]
        public IActionResult DeleteCustomerUser(int id)
        {
            Service.CustomerUser.Delete(id);
            return Ok();
        }
    }
}