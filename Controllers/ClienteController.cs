using Microsoft.AspNetCore.Mvc;

namespace EDAula_202502462032.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Historial()
        {
            return View();
        }
    }
}