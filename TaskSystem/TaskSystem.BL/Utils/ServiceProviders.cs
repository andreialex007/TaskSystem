using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Hosting;

namespace TaskSystem.BL.Utils
{
    public static class ServiceProviders
    {
        public static Func<Microsoft.AspNetCore.Http.HttpContext> HttpContextFunc = null;
        public static Microsoft.AspNetCore.Http.HttpContext HttpContext => HttpContextFunc();


        public static Func<IHostingEnvironment> GetEnvFunc = null;
        public static IHostingEnvironment Environment => GetEnvFunc();


        public static string RootDirectory => Environment.WebRootPath.Replace("wwwroot",string.Empty);
    }
}
