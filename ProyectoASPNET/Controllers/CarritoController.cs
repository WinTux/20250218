using Microsoft.AspNetCore.Mvc;
using ProyectoASPNET.Herramientas;
using ProyectoASPNET.Models.ParaView;
using ProyectoASPNET.Models.Sesiones;

namespace ProyectoASPNET.Controllers
{
    public class CarritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Agregar(string id)
        {
            ProductoModel productoModel = new ProductoModel();
            // No existe la variable de sesion carrito
            if (ConversorJson.GetObjetoDesdeJson<List<Item>>(HttpContext.Session, "carrito") == null)
            {
                List<Item> carrito = new List<Item>();
                carrito.Add(new Item { producto = productoModel.getById(id), cantidad = 1 });
                ConversorJson.SetObjetoAjson(HttpContext.Session, "carrito", carrito);
            }
            else {
                // Sí existe la variable de sesion carrito
                List<Item> carrito = ConversorJson.GetObjetoDesdeJson<List<Item>>(HttpContext.Session, "carrito");
                //TODO crear metodo auxiliar para obtener producto (indice)

                // Si ya existe el producto en el carrito

                // Si no existe el producto en el carrito
            }

            return View();
        }
    }
}
