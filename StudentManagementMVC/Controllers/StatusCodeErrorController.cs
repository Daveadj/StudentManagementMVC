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

                case 500:
                    ViewBag.ErrorMessage = "Internal Server Error";
                    break;
            }
            return View();
        }
    }
}