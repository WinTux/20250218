using Microsoft.EntityFrameworkCore;

namespace ProyectoASPNET.Models
{
    public class MiniMarketXContext : DbContext
    {
        public virtual DbSet<ProyectoASPNET.Models.basededatos.Producto> Productos { get; set; }
        public MiniMarketXContext()
        {
        }
        public MiniMarketXContext(DbContextOptions<MiniMarketXContext> options) : base(options)
        {
        }
    }
}
