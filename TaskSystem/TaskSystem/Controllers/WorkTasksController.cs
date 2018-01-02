using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TaskSystem.BL.Models;
using TaskSystem.DL;
using ControllerBase = TaskSystem.Controllers._Common.ControllerBase;

namespace TaskSystem.Controllers
{
    public class WorkTasksController : ControllerBase
    {
        public WorkTasksController(IConfiguration configuration, AppDbContext appDbContext) : base(configuration, appDbContext)
        {
        }

        [HttpPost]
        [Route("Search")]
        public IActionResult Search(string term, string orderBy, bool isAsc = true, int take = 10, int skip = 0)
        {
            var model = Service.WorkTask.Search(term, orderBy, isAsc, take, skip);
            return Ok(model);
        }


        [HttpGet]
        [Route("CustomerUsers/{id}")]
        public IActionResult CustomerUsers(int id)
        {
            var items = Service.CustomerUser.CustomerUsers(id)
                .Select(x => new { id = x.Id, text = x.Name })
                .ToList();

            return Ok(new { results = items });
        }

        [HttpPost]
        [Route("SearchCustomer")]
        public IActionResult SearchCustomer(string term)
        {
            var items = Service.Customer.Autocomplete(term);
            return Ok(new { results = items });
        }

        [HttpPost]
        [Route("SearchCustomerUsers/{id?}")]
        public IActionResult SearchCustomerUsers(int? id)
        {
            if (!id.HasValue)
                return Ok(new { results = new List<CustomerUserItem>() });
            var items = Service.CustomerUser.CustomerUsers(id.Value);
            return Ok(new { results = items.Select(x => new { id = x.Id, text = x.Name }).ToList() });
        }

        [HttpPost]
        [Route("edit/{id?}")]
        public IActionResult Edit(int? id = null)
        {
            var item = Service.WorkTask.Edit(id);
            return Ok(item);
        }

        [HttpPost]
        [Route("save")]
        public IActionResult Save([FromBody] WorkTaskItem item)
        {
            Service.WorkTask.Save(item);
            return Ok(item);
        }

        [HttpPost]
        [Route("AddNote")]
        public IActionResult AddNote([FromBody] WorkTaskNoteItem item)
        {
            Service.Note.AddNote(item.Note, item.WorkTaskId);
            return Ok(item);
        }

        [HttpPost]
        [Route("delete/{id?}")]
        public IActionResult Delete(int id)
        {
            Service.WorkTask.Delete(id);
            return Ok();
        }
    }
}
