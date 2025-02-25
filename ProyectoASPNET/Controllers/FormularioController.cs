using Microsoft.AspNetCore.Mvc;
using ProyectoASPNET.Models;

namespace ProyectoASPNET.Controllers
{
    public class FormularioController : Controller
    {
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

        public IActionResult Registrar() { 
            
        }
    }
}
