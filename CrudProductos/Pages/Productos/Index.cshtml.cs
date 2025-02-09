using CrudProductos.Datos;
using CrudProductos.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CrudProductos.Pages.Productos
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public IList<Producto> productos { get; set; } // trae la lista de productos
        public async Task OnGet()
        {
            productos = await _context.Producto.ToListAsync();
        }
    }
}
