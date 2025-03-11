using Microsoft.AspNetCore.Mvc;
using ProyectoASPNET.Models;

namespace ProyectoASPNET.Controllers
{
    public class ProductoController : Controller
    {
        // Ejemplo de conexión a base de datos
        private MiniMarketXContext db;
        public ProductoController(MiniMarketXContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            List<ProyectoASPNET.Models.basededatos.Producto> productos = db.Productos.Where(x =>x.Estado==true).ToList();// LinQ
            ViewBag.productos = productos;
            return View();
        }
    }
}
