using Modelo;

namespace DTO
{
    public class ReservaDTO
    {
        public int IdReserva { get; set; }

        public int? IdUsuario { get; set; }
        public DateTime? FechaReserva { get; set; }

        public DateTime FechaEvento { get; set; }

        public decimal? TotalPrecio { get; set; }

        public decimal? TotalPagado { get; set; }

        public bool EstadoReserva { get; set; }

        public virtual ICollection<DetalleReservaDTO> DetalleReservas { get; set; } = new List<DetalleReservaDTO>();

    }
}
