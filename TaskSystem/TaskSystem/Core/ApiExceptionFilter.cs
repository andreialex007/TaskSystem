using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TaskSystem.BL.Exceptions;

namespace TaskSystem.Core
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ValidationException ex)
            {
                context.Result = new JsonResult(new
                {
                    ex.Errors,
                    HasErrors = true
                });

                context.HttpContext.Response.StatusCode = 500;
            }
            base.OnException(context);
        }
    }
}
