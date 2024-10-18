using Examen_U1_Lenguajes.Dtos.Common;
using Examen_U1_Lenguajes.Dtos.SolicitudPermisoDto;
using Examen_U1_Lenguajes.Services.Interfaces;

namespace Examen_U1_Lenguajes.Services
{
    public class SolicitudPermisoServices : ISolicitudPermisoService
    {
        public Task<ResponseDto<SolicitudPermisoDto>> CreateAsync(SolicitudPermisoCreateDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<SolicitudPermisoDto>> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<SolicitudPermisoDto>> EditAsync(RechazarOAprobarSolicitudesEditDto dto, Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<SolicitudPermisoDto>> GetPermisoServiceByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<List<SolicitudPermisoDto>>> GetSolicitudPermisoListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
