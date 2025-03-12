using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoASPNET.Models;
using ProyectoASPNET.Models.basededatos;

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
        #region Lectura registro
        public IActionResult Index()
        {
            List<ProyectoASPNET.Models.basededatos.Producto> productos = db.Productos.ToList();//.Where(x =>x.Estado==true).ToList();// LinQ
            ViewBag.productos = productos;
            return View();
        }
        #endregion

        #region Agergar registros
        [HttpGet]
        public IActionResult Agregar() {
            return View();
        }
        [HttpPost]
        public IActionResult Agregar(Models.basededatos.Producto producto)
        {
            db.Productos.Add(producto);
            //db.Add(producto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

        #region Editar registro
        [HttpGet]
        public IActionResult Editar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Editar(Models.basededatos.Producto producto)
        {
            db.Entry(producto).State = EntityState.Modified;
            //db.Add(producto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

        #region Eliminar registro
        [HttpGet]
        public IActionResult Eliminar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            db.Productos.Remove(db.Productos.Find(id));
            //db.Add(producto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion
    }
}
