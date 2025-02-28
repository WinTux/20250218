using System.ComponentModel.DataAnnotations;

namespace ProyectoASPNET.Models
{
    public class Cuenta
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Password { get;set; }
        public string Descripcion {  get; set; }
        public bool Disponible { get; set; }
        public string Genero { get; set; } // M (Masculino), F (Femenino)
        public List<string> Lenguajes { get; set; } // l01, l02, etc.
        public string Cargo { get; set; } // c01, c02
    }

    namespace Validacion {
        public class Cuenta {
            [Required(ErrorMessage ="El nombre de usuario es obligatorio")]
            [MinLength(3)]
            [MaxLength(10)]
            public string usuario {  get; set; } // X, F, Rs, Hq
            [Required]
            [MinLength(3)]
            [MaxLength(10, ErrorMessage ="Solo puede contar con 10 letras")]
            [RegularExpression("((?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[$%@#]).{6,20})",ErrorMessage ="El password debe contar con al menos un dígito, una letra minúscula...")]
            public string password { get; set; } // >=8 abcABC&123
            [Required]
            [Range(18,50, ErrorMessage ="La edad debe estar entre 18 y 50 años")]
            public int edad {  get; set; }
            [Required]
            [EmailAddress(ErrorMessage ="Escriba un correo electrónico valido")]
            public string email { get; set; }
            [Url]
            public string? paginaweb {  get; set; }
        }
    }
}
