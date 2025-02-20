using Microsoft.AspNetCore.Mvc;

namespace ProyectoASPNET.Controllers
{
    public class ValoresDeSettingsController : Controller
    {
        private IConfiguration _configuration;
        public ValoresDeSettingsController(IConfiguration configuration) { 
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            ViewBag.valor1 = _configuration["Mensaje"];
            ViewBag.valor2 = _configuration["MisConfiguraciones:Configuracion1"];
            ViewBag.valor3 = _configuration["MisConfiguraciones:Configuracion2"];
            ViewBag.valor4 = _configuration["MisConfiguraciones:Configuracion3"];
            ViewBag.valor5 = _configuration["Logging:LogLevel:Microsoft.AspNetCore"];
            return View();
        }
    }
}
