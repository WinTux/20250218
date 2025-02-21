using Microsoft.AspNetCore.Mvc;

namespace ProyectoASPNET.Controllers
{
    [Route("propiedades")] // https://localhost:7070/propiedades
    public class ValoresDeSettingsController : Controller
    {
        private IConfiguration _configuration;
        public ValoresDeSettingsController(IConfiguration configuration) { 
            _configuration = configuration;
        }
        [Route("")] // https://localhost:7070/propiedades
        [Route("listar")] // https://localhost:7070/propiedades/index
        [Route("~/")] // https://localhost:7070/propiedades/
        public IActionResult Index()
        {
            ViewBag.valor1 = _configuration["Mensaje"];
            ViewBag.valor2 = _configuration["MisConfiguraciones:Configuracion1"];
            ViewBag.valor3 = _configuration["MisConfiguraciones:Configuracion2"];
            ViewBag.valor4 = _configuration["MisConfiguraciones:Configuracion3"];
            ViewBag.valor5 = _configuration["Logging:LogLevel:Microsoft.AspNetCore"];
            return View();
        }
        [Route("Diferente")] // https://localhost:7070/propiedades/Diferente
        public IActionResult Diferente() {
            return View();
        }
    }
}
