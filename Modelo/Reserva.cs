using System;
using System.Collections.Generic;

namespace Modelo;

public partial class Reserva
{
    public int IdReserva { get; set; }

    public int? IdUsuario { get; set; }

    public DateTime? FechaReserva { get; set; }

    public DateTime? FechaEvento { get; set; }

    public decimal? TotalPrecio { get; set; }

    public decimal? TotalPagado { get; set; }

    public bool? EstadoReserva { get; set; }

    public virtual ICollection<DetalleReserva> DetalleReservas { get; set; } = new List<DetalleReserva>();

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
