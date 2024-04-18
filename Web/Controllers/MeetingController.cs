using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class MeetingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
