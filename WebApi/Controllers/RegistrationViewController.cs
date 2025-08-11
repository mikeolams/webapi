using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class RegistrationViewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
