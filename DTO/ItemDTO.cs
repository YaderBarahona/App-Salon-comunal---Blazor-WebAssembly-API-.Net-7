﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ItemDTO
    {
        public int? IdProducto { get; set; }

        public string? Nombre { get; set; }

        public decimal? Precio { get; set; }

        public int? Cantidad { get; set; }


    }
}
