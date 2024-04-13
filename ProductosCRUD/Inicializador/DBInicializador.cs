using Microsoft.EntityFrameworkCore;
using ProductosCRUD.Datos;

namespace ProductosCRUD.Inicializador
{
    public class DBInicializador : IBdInicializador
    {
        private readonly ApplicationDbContext _context;

        public DBInicializador(ApplicationDbContext context)
        {
            _context = context; 
        }
        public void Inicializar()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Count() > 0)
                {
                    _context.Database.Migrate();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
