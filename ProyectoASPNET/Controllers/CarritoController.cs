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
            var carrito = ConversorJson.GetObjetoDesdeJson<List<Item>>(HttpContext.Session, "carrito");
            ViewBag.carrito = carrito;
            ViewBag.total = carrito.Sum(item => item.producto.Precio * item.cantidad);
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
                int indice = ExisteProducto(id);
                if(indice != -1)
                {
                    // Si ya existe el producto en el carrito
                    carrito[indice].cantidad++;
                }
                else
                {
                    // Si no existe el producto en el carrito
                    carrito.Add(new Item { producto = productoModel.getById(id), cantidad = 1 });
                }
                ConversorJson.SetObjetoAjson(HttpContext.Session, "carrito", carrito);
            }

            return RedirectToAction("Index");
        }
        [Route("Quitar/{id}")]
        public IActionResult Quitar(string id) {
            List<Item> carrito = ConversorJson.GetObjetoDesdeJson<List<Item>>(HttpContext.Session, "carrito");
            int indice = ExisteProducto(id);
            carrito.RemoveAt(indice);
            ConversorJson.SetObjetoAjson(HttpContext.Session, "carrito", carrito);
            return RedirectToAction("Index");
        }
        [NonAction]
        private int ExisteProducto(string id)
        {
            List<Item> carrito = ConversorJson.GetObjetoDesdeJson<List<Item>>(HttpContext.Session, "carrito");
            for (int i = 0; i < carrito.Count; i++)
                if (carrito[i].producto.Id.Equals(id))
                    return i;
            return -1;
        }
    }
}
