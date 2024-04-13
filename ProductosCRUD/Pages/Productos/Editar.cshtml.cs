using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductosCRUD.Datos;
using ProductosCRUD.Modelos;

namespace ProductosCRUD.Pages.Productos
{
    public class EditarModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditarModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Producto Producto { get; set; }
        public async Task OnGet(int id)
        {
            Producto = await _context.Producto.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)

            {
                var ProductoDB = await _context.Producto.FindAsync(Producto.Id);
                ProductoDB.NombreProducto = Producto.NombreProducto;
                ProductoDB.Descripcion = Producto.Descripcion;
                ProductoDB.EnStock = Producto.EnStock;
                ProductoDB.Precio = Producto.Precio;

                await _context.SaveChangesAsync();

                return RedirectToPage("Index");
            }

            return RedirectToPage();
        }
    }
}
