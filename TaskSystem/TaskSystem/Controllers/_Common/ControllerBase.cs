using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TaskSystem.BL.Common;
using TaskSystem.BL.Utils;
using TaskSystem.Code;
using TaskSystem.DL;

namespace TaskSystem.Controllers._Common
{
    [Authorize("Bearer")]
    [ApiExceptionFilter]
    [Route("api/[controller]")]
    public class ControllerBase : Controller
    {
        protected IConfiguration Configuration;

        protected AppService Service { get; set; }

        public ControllerBase(IConfiguration configuration, AppDbContext appDbContext)
        {
            ServiceProviders.HttpContextFunc = () => HttpContext;
            Configuration = configuration;
            Service = new AppService(appDbContext);
        }
    }


    
}