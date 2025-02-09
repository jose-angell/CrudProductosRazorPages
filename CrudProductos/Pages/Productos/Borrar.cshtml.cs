using CrudProductos.Datos;
using CrudProductos.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CrudProductos.Pages.Productos
{
    public class BorrarModel : PageModel
    {
        public readonly ApplicationDbContext _context;
        public BorrarModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Producto Producto { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Producto = await _context.Producto.FirstOrDefaultAsync(x => x.Id == id);
            if(Producto == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnpostAsync()
        {
            if(Producto == null)
            {
                return NotFound();
            }
            var prodcuctoBorrar = await _context.Producto.FindAsync(Producto.Id);
            if(prodcuctoBorrar != null)
            {
                _context.Remove(prodcuctoBorrar);
                await _context.SaveChangesAsync();
            }


            return RedirectToPage("Index");
        }
    }
}
