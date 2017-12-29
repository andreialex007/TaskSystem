using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TaskSystem.DL;
using ControllerBase = TaskSystem.Controllers._Common.ControllerBase;

namespace TaskSystem.Controllers
{
    public class CustomersController : ControllerBase
    {
        public CustomersController(IConfiguration configuration, AppDbContext appDbContext) : base(configuration, appDbContext)
        {
        }

        [HttpPost]
        [Route("Search")]
        public IActionResult Search(string term, string orderBy, bool isAsc = true, int take = 10, int skip = 0)
        {
            var model = Service.Customer.Search(term, orderBy, isAsc, take, skip);
            return Ok(model);
        }
    }
}