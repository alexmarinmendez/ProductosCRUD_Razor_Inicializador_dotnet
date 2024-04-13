using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProductosCRUD.Datos;
using ProductosCRUD.Modelos;

namespace ProductosCRUD.Pages.Productos
{
    public class IndexModel : PageModel
    {
        public readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Producto> Productos { get; set; }

        public async Task OnGet()
        {
            Productos = await _context.Producto.ToListAsync();
        }

        public async Task<IActionResult> OnPostBorrar(int id)
        {
            var producto = await _context.Producto.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            _context.Producto.Remove(producto);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
