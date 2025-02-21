using Microsoft.AspNetCore.Mvc;

namespace ProyectoASPNET.Controllers
{
    [Route("parametros")]
    public class ParametrosController : Controller
    {
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("Ejemplo1/{id}")] // https://localhost:7070/parametros/Ejemplo1/123
        public IActionResult Ejemplo1(int id)
        {
            ViewBag.Id = id;
            return View();
        }

    }
}
