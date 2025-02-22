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
        [Route("Ejemplo2/{id}/{id2}")] // https://localhost:7070/parametros/Ejemplo2/123/producto07
        public IActionResult Ejemplo2(int id,string id2)
        {
            ViewBag.Id = id;
            ViewBag.Id2 = id2;
            return View("DosParametros");
        }
        [Route("Ejemplo3")] // https://localhost:7070/parametros/Ejemplo3?prod=producto123
        public IActionResult Ejemplo3([FromQuery(Name ="prod")] string id)
        {
            ViewBag.Id = id;
            return View("QueryStrings1");
        }
        [Route("Ejemplo4")] // https://localhost:7070/parametros/Ejemplo4?idprod=11&prod=producto123
        public IActionResult Ejemplo4([FromQuery(Name = "prod")] string producto, [FromQuery(Name ="idprod")] int idproducto)
        {
            ViewBag.Id = idproducto;
            ViewBag.Nombre = producto;
            return View("QueryStrings2");
        }
        [Route("Ejemplo5")] // https://localhost:7070/parametros/Ejemplo5?idprod=11&prod=producto123
        public IActionResult Ejemplo5() {
            var idproducto = int.Parse(HttpContext.Request.Query["idprod"].ToString());
            var producto = HttpContext.Request.Query["prod"].ToString();
            ViewBag.Id = idproducto;
            ViewBag.Nombre = producto;
            return View("QueryStrings2");
        }
    }
}
