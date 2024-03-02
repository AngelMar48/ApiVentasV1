using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ApiVentasV1
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Persona, PersonaFullName>()
                .ForMember(c => c.FullName,
                     opt => opt.MapFrom(x => string.Join(' ', x.Nombre, x.ApellidoPaterno, x.ApellidoPaterno)));
            CreateMap<Factura, FacturaDto>();

            CreateMap<Persona, PersonaDto>();

            CreateMap<NuevaPersona, Persona>();

            CreateMap<NuevaFactura, Factura>();

            CreateMap<PersonaManipulate, Persona>();



        }
    }
}
