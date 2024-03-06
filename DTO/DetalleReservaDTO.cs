using Modelo;

namespace DTO
{
    public class DetalleReservaDTO
    {
        public int IdDetalleReserva { get; set; }

        public int? IdReserva { get; set; }

        public int? IdProducto { get; set; }

        public int? Cantidad { get; set; }

        public decimal? Total { get; set; }
    }
}
