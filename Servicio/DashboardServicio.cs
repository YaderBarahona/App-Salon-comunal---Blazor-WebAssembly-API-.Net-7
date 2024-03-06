using DTO;
using Modelo;
using Repositorio.IRepositorio;
using Servicio.IServicio;

namespace Servicio
{
    public class DashboardServicio : IDashboardServicio
    {
        private readonly IReservaRepositorio _reservaRepositorio;
        private readonly IGenericoRepositorio<Usuario> _usuarioRepositorio;
        private readonly IGenericoRepositorio<Producto> _productoRepositorio;

        public DashboardServicio(IReservaRepositorio reservaRepositorio,
            IGenericoRepositorio<Usuario> usuarioRepositorio,
            IGenericoRepositorio<Producto> productoRepositorio)
        {
            _reservaRepositorio = reservaRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
            _productoRepositorio = productoRepositorio;
        }

        private string Ingresos()
        {
            var query = _reservaRepositorio.Consultar();
            decimal? ingresos = query.Sum(x => x.TotalPagado);

            return Convert.ToString(ingresos);
        }

        private int Reservas()
        {
            var query = _reservaRepositorio.Consultar();
            int total = query.Count();

            return total;
        }

        private int Clientes()
        {
            var query = _usuarioRepositorio.Consultar(u => u.Rol.ToLower() == "cliente");
            int total = query.Count();

            return total;
        }

        private int Productos()
        {
            var query = _productoRepositorio.Consultar();
            int total = query.Count();

            return total;
        }

        public DashboardDTO Resumen()
        {
            try
            {
                DashboardDTO dto = new DashboardDTO()
                {
                    TotalIngresos = Ingresos(),
                    TotalReservas = Reservas(),
                    TotalClientes = Clientes(),
                    TotalProductos = Productos(),
                };

                return dto;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
