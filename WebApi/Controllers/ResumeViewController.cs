using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class ResumeViewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
