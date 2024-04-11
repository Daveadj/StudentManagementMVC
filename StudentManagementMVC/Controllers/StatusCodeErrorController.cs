using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace StudentManagementMVC.Controllers
{
    public class StatusCodeErrorController : Controller
    {
        [HttpGet("/StatusCodeError/{statusCode}")]
        public ActionResult Error(int statuscode)
        {
            switch (statuscode)
            {
                case 404:
                    ViewBag.ErrorMessage = "404 Page Not Found";
                    break;

                case 400:
                    ViewBag.ErrorMessage = "Bad Request";
                    break;
            }
            return View();
        }

        [Route("StatusCodeError")]
        [AllowAnonymous]
        public IActionResult ServerError()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerFeature>();
            ;

            return View();
        }
    }
}