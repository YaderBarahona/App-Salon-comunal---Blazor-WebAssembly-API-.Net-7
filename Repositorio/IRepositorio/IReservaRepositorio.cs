using DTO;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.IRepositorio
{
    public interface IReservaRepositorio : IGenericoRepositorio<Reserva>
    {
        Task<Reserva> Registrar(Reserva modelo);

    }
}
