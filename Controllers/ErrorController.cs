using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Webshop.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var statusCode = exception.Error.GetType().Name switch
            {
                "Exception" => HttpStatusCode.InternalServerError,
                "ArgumentException" => HttpStatusCode.BadRequest,
                _ => HttpStatusCode.InternalServerError
            };
            return Problem(detail: exception.Error.Message, statusCode: (int)statusCode);
        }
    }
}
