using System;
using System.Collections.Generic;

namespace Modelo;

public partial class DetalleReserva
{
    public int IdDetalleReserva { get; set; }

    public int? IdReserva { get; set; }

    public int? IdProducto { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Total { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }

    public virtual Reserva? IdReservaNavigation { get; set; }
}
