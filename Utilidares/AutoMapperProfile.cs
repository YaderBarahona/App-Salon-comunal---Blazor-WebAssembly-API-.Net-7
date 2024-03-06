using AutoMapper;
using DTO;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Conviertiendo Usuario a UsuarioDTO
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<Usuario, SesionDTO>();
            CreateMap<UsuarioDTO, Usuario>();

            CreateMap<Categoria, CategoriaDTO>();
            CreateMap<CategoriaDTO, Categoria>();

            CreateMap<Producto, ProductoDTO>();
            //omitir propiedad de productDTO al convertir a Producto
            CreateMap<ProductoDTO, Producto>().ForMember(destino => destino.IdCategoriaNavigation, opt => opt.Ignore());

            CreateMap<DetalleReserva, DetalleReservaDTO>();
            CreateMap<DetalleReservaDTO, DetalleReserva>();

            CreateMap<Reserva, ReservaDTO>();
            CreateMap<ReservaDTO, Reserva>();

        }
    }
}
