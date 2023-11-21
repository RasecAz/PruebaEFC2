using Microsoft.EntityFrameworkCore;
using PruebaEFC.Entidades;

namespace PruebaEFC
{
    public class ApplicationDbContex : DbContext
    {
        public ApplicationDbContex(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Prueba> Pruebas => Set<Prueba>();
    }
}
