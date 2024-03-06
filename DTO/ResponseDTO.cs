using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    //clase para almacenar las respuestas a las solicitudes de la API
    //generico para trabajar con cualquier modelo
    public class ResponseDTO<T>
    {
        public T? Resultado { get; set; }

        public bool Ok { get; set; }

        public string? Message { get; set; }
    }
}
