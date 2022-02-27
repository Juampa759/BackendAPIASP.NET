using Microsoft.EntityFrameworkCore;
using PruebaFamiliar.Entidades;

namespace PruebaFamiliar
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext( DbContextOptions options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
