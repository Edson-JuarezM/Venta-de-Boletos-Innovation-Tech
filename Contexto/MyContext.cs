using Microsoft.EntityFrameworkCore;
using SuperChampiniones.Models;

namespace SuperChampiniones.Contexto
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions options):base (options) { }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<SuperChampiniones.Models.Miembro_Vip> Miembro_Vip { get; set; } = default!;
        public DbSet<SuperChampiniones.Models.Partido> Partido { get; set; } = default!;
    }
}
