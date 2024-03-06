using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProductoDTO
    {
        public int IdProducto { get; set; }

        [Required(ErrorMessage = "Ingresa el nombre del producto")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Ingresa la descripción del producto")]
        public string? Descripcion { get; set; }

        public int? IdCategoria { get; set; }

        [Required(ErrorMessage = "Ingresa el precio del producto")]
        public decimal? Precio { get; set; }

        [Required(ErrorMessage = "Ingresa la cantidad del producto")]
        public int? Cantidad { get; set; }

        [Required(ErrorMessage = "Ingresa la imagen del producto")]
        public string? Imagen { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual CategoriaDTO? IdCategoriaNavigation { get; set; }

    }
}
