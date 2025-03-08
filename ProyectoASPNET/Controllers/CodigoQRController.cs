using Microsoft.AspNetCore.Mvc;

namespace ProyectoASPNET.Controllers
{
    public class CodigoQRController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GenerarCodigoQR(string productoid)
        {
            ViewBag.prodId = productoid;
            return View("Index");
        }
    }
}
