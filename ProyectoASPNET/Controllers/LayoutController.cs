using Microsoft.AspNetCore.Mvc;

namespace ProyectoASPNET.Controllers
{
    public class LayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Acerca()
        {
            ViewBag.titulo = "ACERCA DE";
            return View();
        }
        public IActionResult Noticias()
        {
            return View();
        }
    }
}
