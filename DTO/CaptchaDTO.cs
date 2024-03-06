using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CaptchaDTO
    {
        [Required(ErrorMessage = "Código captcha incorrecto")]
        public string? Code { get; set; }
    }
}
