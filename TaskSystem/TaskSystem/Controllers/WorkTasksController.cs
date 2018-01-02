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
        [Route("delete/{id?}")]
        public IActionResult Delete(int id)
        {
            Service.WorkTask.Delete(id);
            return Ok();
        }
    }
}
