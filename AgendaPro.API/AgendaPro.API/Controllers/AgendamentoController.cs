using Microsoft.AspNetCore.Mvc;

namespace AgendaPro.API.Controllers
{
    public class AgendamentoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
