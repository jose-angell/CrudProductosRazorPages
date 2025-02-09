using CrudProductos.Modelos;
using Microsoft.EntityFrameworkCore;

namespace CrudProductos.Datos
{
    public class ApplicationDbContext: DbContext
    {
        // constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        //Agregar los modelos (Todos los modelos creado se colocan aqui)
        public DbSet<Producto> Producto { get; set; }

    }
}
