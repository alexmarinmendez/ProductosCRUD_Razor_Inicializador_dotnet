using Microsoft.EntityFrameworkCore;
using ProductosCRUD.Modelos;

namespace ProductosCRUD.Datos
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        // Poner aquí los modelos!!!
        public DbSet<Producto> Producto { get; set; }
    }
}
