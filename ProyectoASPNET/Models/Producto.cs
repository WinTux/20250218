using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoASPNET.Models
{
    public class Producto
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Foto { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
    }
    namespace Sesiones {
        public class Producto
        {
            public string Id { get; set; }
            public string Nombre { get; set; }
            public string Foto { get; set; }
            public double Precio { get; set; }
        }

        public class Item { 
            public Producto producto { get; set; }
            public int cantidad { get; set; }
        }
    }
    namespace basededatos
    {
        [Table("Producto")]
        public class Producto
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public decimal Precio { get; set; }
            public int Cantidad { get; set; }
            public bool Estado { get; set; }
        }
    }
}
