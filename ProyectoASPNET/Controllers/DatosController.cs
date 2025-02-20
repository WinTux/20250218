using Microsoft.AspNetCore.Mvc;
using ProyectoASPNET.Models;

namespace ProyectoASPNET.Controllers
{
    public class DatosController : Controller
    {
        public IActionResult Index() //http://localhost:5050/Datos/Index
        {
            // Pasar datos desde el controlador a la vista
            ViewBag.edad = 23;
            ViewBag.nombre = "Pepe Perales";
            ViewBag.casado = false;
            ViewBag.estatura = 1.73;
            ViewBag.fechaNacimiento = DateTime.Now;

            Producto prod = new Producto { 
                Id = "prod001",
                Nombre = "Atún VanCamp's",
                Foto = "atun.jpg",
                Precio = 20.5,
                Cantidad = 24
            };

            var productos = new List<Producto> {
                new Producto {
                Id = "prod001",
                Nombre = "Atún VanCamp's",
                Foto = "atun.jpg",
                Precio = 20.5,
                Cantidad = 24
            },
                new Producto {
                Id = "prod002",
                Nombre = "Helado cassata 1L",
                Foto = "helado1.jfif",
                Precio = 12,
                Cantidad = 12
            },
                new Producto {
                Id = "prod003",
                Nombre = "Helado cassata 2.5L",
                Foto = "helado2.jfif",
                Precio = 10.8,
                Cantidad = 10
            },
                new Producto {
                Id = "prod004",
                Nombre = "Limonada en vaso",
                Foto = "limonada2.jpg",
                Precio = 20,
                Cantidad = 5
            }
            };
            ViewBag.producto = prod;
            ViewBag.productos = productos;
            return View();
        }
    }
}
