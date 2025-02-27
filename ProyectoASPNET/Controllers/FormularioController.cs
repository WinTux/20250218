using Microsoft.AspNetCore.Mvc;
using ProyectoASPNET.Models;

namespace ProyectoASPNET.Controllers
{
    public class FormularioController : Controller
    {
        private IWebHostEnvironment webHostEnvironment;

        public FormularioController(IWebHostEnvironment webHostEnvironment) {
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var cuentaViewModel = new CuentaViewModel();
            cuentaViewModel.Cuenta = new Cuenta()
            {
                Id = 123,
                Disponible = true,
                Genero = "F",
            };
            cuentaViewModel.Lenguajes = new List<Lenguaje>() { 
                new Lenguaje(){Id="l01",Nombre="C#",estaTickeado=true},
                new Lenguaje(){Id="l02",Nombre="Python",estaTickeado=false},
                new Lenguaje(){Id="l03",Nombre="Java",estaTickeado=false},
                new Lenguaje(){Id="l04",Nombre="Rust",estaTickeado=false}
            };
            var cargos = new List<Cargo>() {
                new Cargo { Id="c01",Nombre="Auxiliar de desarrollo"},
                new Cargo { Id="c02",Nombre="Administrador de sistemas"},
                new Cargo { Id="c03",Nombre="Administrador de Bases de Datos"},
                new Cargo { Id="c04",Nombre="Soporte y TICs"}
            };
            cuentaViewModel.Cargos = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(cargos, "Id", "Nombre");// llave->valor
            return View("Index",cuentaViewModel);//View(), View("abc"), View("abc",object)
        }
        [HttpPost]
        public IActionResult Registrar(CuentaViewModel cvm, List<Lenguaje> Lenguajes) {
            cvm.Cuenta.Lenguajes = new List<string>();
            foreach (var len in Lenguajes) {
                if (len.estaTickeado) {
                    cvm.Cuenta.Lenguajes.Add(len.Id);
                }
            }
            ViewBag.cuenta = cvm.Cuenta;
            return View("Registrado");
        }
        #region Formulario que envíe un archivo
        public IActionResult FormConArchivo() {
            return View("FormConArchivo",new Producto());
        }
        [HttpPost]
        public IActionResult RegistroProducto(Producto prod, IFormFile foto)
        {
            if (foto == null || foto.Length == 0)
                return Content("Archivo no válido.");
            else {
                var ruta = Path.Combine(webHostEnvironment.WebRootPath,"imagenes",foto.FileName);// "a","b","c" -> a\b\c -> a/b/c
                var stream = new FileStream(ruta,FileMode.Create);
                foto.CopyToAsync(stream);
                prod.Foto = foto.FileName;
                ViewBag.producto = prod;
                return View();
            }
            
        }
        #endregion
    }
}
