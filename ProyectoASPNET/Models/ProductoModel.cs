
namespace ProyectoASPNET.Models.ParaView
{
    public class ProductoModel
    {
        private List<ProyectoASPNET.Models.Sesiones.Producto> productos;
        public ProductoModel() {
            productos = new List<ProyectoASPNET.Models.Sesiones.Producto>()
            {
                new ProyectoASPNET.Models.Sesiones.Producto { Id = "p01", Nombre = "Laptop", Precio = 1500.00, Foto = "laptop.jpg" },
                new ProyectoASPNET.Models.Sesiones.Producto { Id = "p02", Nombre = "Netbook", Precio = 900.00, Foto = "netbook.jpg" },
                new ProyectoASPNET.Models.Sesiones.Producto { Id = "p03", Nombre = "Tablet", Precio = 800.00, Foto = "tablet.jpg" }

            };
        }
        public List<ProyectoASPNET.Models.Sesiones.Producto> getTodo() {
            return productos;
        }
        public ProyectoASPNET.Models.Sesiones.Producto getById(string id)
        {
            // LINQ
            // SELECT * FROM productos p WHERE p.id = 'p03';
            //return productos.FirstOrDefault(p => p.Id == id);
            //return productos.Find(p => p.Id == id);
            return productos.Single(p => p.Id == id);
        }
    }
}
