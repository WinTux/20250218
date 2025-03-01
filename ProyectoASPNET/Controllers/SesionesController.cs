using Microsoft.AspNetCore.Mvc;
using ProyectoASPNET.Herramientas;
using ProyectoASPNET.Models;

namespace ProyectoASPNET.Controllers
{
    public class SesionesController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.SetString("usuario", "admin"); // llave - valor
            if(HttpContext.Session.GetInt32("edad") == null)
                HttpContext.Session.SetInt32("edad", new Random().Next());
            
            Producto producto = new Producto { 
                Id = "p01",
                Nombre = "Laptop",
                Precio = 1500.00,
                Cantidad = 10,
                Foto = "laptop.jpg"
            };
            // {"Id":"p01","Nombre":"Laptop","Precio":1500.00}
            ConversorJson.SetObjetoAjson(HttpContext.Session, "prod", producto);
            List<Producto> productos = new List<Producto> {
                new Producto { Id = "p01", Nombre = "Laptop", Precio = 1500.00, Cantidad = 10, Foto = "laptop.jpg" },
                new Producto { Id = "p02", Nombre = "Mouse", Precio = 20.00, Cantidad = 100, Foto = "mouse.jpg" }
            };
            ConversorJson.SetObjetoAjson(HttpContext.Session, "prods", productos);
            return View();
        }
    }
}
