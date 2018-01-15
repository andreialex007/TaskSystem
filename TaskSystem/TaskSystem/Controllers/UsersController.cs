using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TaskSystem.BL.Models;
using TaskSystem.DL;
using ControllerBase = TaskSystem.Controllers._Common.ControllerBase;

namespace TaskSystem.Controllers
{
    public class UsersController : ControllerBase
    {
        public UsersController(IConfiguration configuration, AppDbContext appDbContext, IHostingEnvironment environment) 
            : base(configuration, appDbContext, environment)
        {
        }

        [HttpPost]
        [Route("All")]
        public IActionResult All()
        {
            var users = Service.User.All();
            return Ok(users);
        }

        [HttpPost]
        [Route("edit/{id?}")]
        public IActionResult Edit(int? id = null)
        {
            var users = Service.User.Edit(id);
            return Ok(users);
        }

        [HttpPost]
        [Route("save")]
        public IActionResult Save([FromBody] UserItem item)
        {
            Service.User.Save(item);
            return Ok(item);
        }

        [HttpPost]
        [Route("delete/{id?}")]
        public IActionResult Delete(int id)
        {
            Service.User.Delete(id);
            return Ok();
        }

    }
}
