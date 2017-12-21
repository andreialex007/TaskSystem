using System;
using System.Collections.Generic;
using System.Text;

namespace TaskSystem.BL.Utils
{
    public static class ServiceProviders
    {
        public static Func<Microsoft.AspNetCore.Http.HttpContext> HttpContextFunc = null;
        public static Microsoft.AspNetCore.Http.HttpContext HttpContext => HttpContextFunc();
    }
}
