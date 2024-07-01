using Microsoft.EntityFrameworkCore;
using SuperChampiniones.Models;

namespace SuperChampiniones.Contexto
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Miembro_Vip> Miembro_Vip { get; set; }
        public DbSet<Partido> Partido { get; set; }
    }
}
