using CrudProductos.Datos;
using CrudProductos.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrudProductos.Pages.Productos
{
    public class CrearModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        //ctor atajo para crear el constructor de forma automatica
        public CrearModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Producto Producto { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //asignar la fecha y hora actual al campo fechaCreacion
            Producto.FechaCreacion = DateTime.Now;

            _context.Producto.Add(Producto);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
