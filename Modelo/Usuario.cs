﻿using System;
using System.Collections.Generic;

namespace Modelo;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Nombre { get; set; } 

    public string? Correo { get; set; } 

    public string? Clave { get; set; } 

    public string? Rol { get; set; } 

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
