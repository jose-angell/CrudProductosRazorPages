using CrudProductos.Datos;
using CrudProductos.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CrudProductos.Pages.Productos
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
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Producto = await _context.Producto.FirstOrDefaultAsync(p => p.Id == id);
            if (Producto == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Producto.FechaCreacion = DateTime.Now;
            // establece el estado del modelo a modificado, indicando que al guardar estos cambio debe
            // modificar todos los campos del modelo
            _context.Attach(Producto).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //manejo de errores de concurrencia, si el producto que quieres modificar ya no existe
                //en la base de datos te avisa del error
                if (!ProductoExiste(Producto.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            
            return RedirectToPage("Index");
        }
        private bool ProductoExiste(int id)
        {
            return _context.Producto.Any(p => p.Id == id);
        }
    }
}
