using Microsoft.AspNetCore.Mvc;

namespace AgendaPro.API.Controllers
{
    public class ServicoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
