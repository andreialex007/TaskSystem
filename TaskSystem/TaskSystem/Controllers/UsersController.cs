using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TaskSystem.DL;
using ControllerBase = TaskSystem.Controllers._Common.ControllerBase;

namespace TaskSystem.Controllers
{
    public class UsersController : ControllerBase
    {
        public UsersController(IConfiguration configuration, AppDbContext appDbContext) : base(configuration, appDbContext)
        {
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("All")]
        public IActionResult All()
        {
            var users = Service.User.All();
            return Ok(users);
        }

    }
}
