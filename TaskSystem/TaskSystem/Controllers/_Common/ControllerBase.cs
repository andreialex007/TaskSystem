using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TaskSystem.BL.Utils;

namespace TaskSystem.Controllers._Common
{
    [Authorize]
    [Route("api/[controller]")]
    public class ControllerBase : Controller
    {
        protected IConfiguration Configuration;

        public ControllerBase(IConfiguration configuration)
        {
            ServiceProviders.HttpContextFunc = () => HttpContext;
            Configuration = configuration;
        }
    }
}