using System.ComponentModel.DataAnnotations;

namespace CrudProductos.Modelos
{
    public class Producto
    {
        //EF indentifica automaticamente que es una llave primaria
        [Key] // para hacerlo explicitamente (en este caso el nombre de la llave primaria puede ser el que se nececite
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")] //validacion del lado del servidor
        public string Nombre { get; set; }
        [Range(1, 1000, ErrorMessage = "El precio debe estar enre 1 y 1000 usd")] // validacion de rangos de valores
        public decimal Precio { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "El Stock no puede ser negativo")]
        public int Stock { get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}
