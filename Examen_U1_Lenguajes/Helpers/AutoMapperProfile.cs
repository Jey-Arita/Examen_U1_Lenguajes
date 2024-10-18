using AutoMapper;
using Examen_U1_Lenguajes.Database.Entities;
using Examen_U1_Lenguajes.Dtos.SolicitudPermisoDto;

namespace Examen_U1_Lenguajes.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            MapsForSolicitudPermiso();
        }
        private void MapsForSolicitudPermiso()
        {
            CreateMap<SolicitudPermisoEntitty, SolicitudPermisoDto>();
            CreateMap<SolicitudPermisoCreateDto, SolicitudPermisoEntitty>().ForMember(dest => dest.Solicitud, opt => opt.Ignore()) // Lo generas tú
            .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => "Pendiente")); ;
            CreateMap<RechazarOAprobarSolicitudesEditDto, SolicitudPermisoEntitty>();
        }
    }
}
