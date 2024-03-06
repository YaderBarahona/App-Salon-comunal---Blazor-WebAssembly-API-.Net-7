using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Ingresa el nombre completo")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "Ingresa el correo electrónico")]
        public string? Correo { get; set; }
        [Required(ErrorMessage = "Ingresa la contraseña")]
        public string? Clave { get; set; }
        [Required(ErrorMessage = "Ingresa la confirmación de la contraseña")]
        public string? ConfirmarClave { get; set; }

        public string? Rol { get; set; }

    }
}
