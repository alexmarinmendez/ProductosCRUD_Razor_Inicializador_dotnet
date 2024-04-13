using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductosCRUD.Datos;
using ProductosCRUD.Modelos;

namespace ProductosCRUD.Pages.Productos
{
    public class CrearModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CrearModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Producto Producto { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Producto.FechaCreacion = DateTime.Now;

            _context.Add(Producto);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
