using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    //clase para el formulario de login
    public class LoginDTO
    {
        [Required(ErrorMessage = "Ingresa el correo electrónico")]
        public string? Correo { get; set; }
        [Required(ErrorMessage = "Ingresa la contraseña")]
        public string? Clave { get; set; }
    }
}
