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
}
