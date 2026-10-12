using Microsoft.AspNetCore.Mvc;

namespace AgendaPro.API.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
