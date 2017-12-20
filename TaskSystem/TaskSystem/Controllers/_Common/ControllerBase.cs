using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace TaskSystem.Controllers._Common
{
    [Authorize]
    [Route("api/[controller]")]
    public class ControllerBase : Controller
    {
        protected IConfiguration Configuration;

        public ControllerBase(IConfiguration configuration)
        {
            Configuration = configuration;
            //this.Configuration["SecurityKey"]
        }
    }
}
