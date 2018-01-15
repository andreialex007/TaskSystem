using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
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
        protected IHostingEnvironment HostingEnvironment;

        protected AppService Service { get; set; }

        public ControllerBase(IConfiguration configuration, AppDbContext appDbContext, IHostingEnvironment hostingEnvironment)
        {
            ServiceProviders.HttpContextFunc = () => HttpContext;
            ServiceProviders.GetEnvFunc = () => hostingEnvironment;
            Configuration = configuration;
            HostingEnvironment = hostingEnvironment;
            Service = new AppService(appDbContext);
        } 
    }



}