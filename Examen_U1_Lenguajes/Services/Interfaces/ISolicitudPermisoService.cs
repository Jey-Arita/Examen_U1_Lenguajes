using Examen_U1_Lenguajes.Dtos.Common;
using Examen_U1_Lenguajes.Dtos.SolicitudPermisoDto;

namespace Examen_U1_Lenguajes.Services.Interfaces
{
    public interface ISolicitudPermisoService
    {
        Task<ResponseDto<List<SolicitudPermisoDto>>> GetSolicitudPermisoListAsync();
        Task<ResponseDto<SolicitudPermisoDto>> GetPermisoServiceByIdAsync(Guid id);
        Task<ResponseDto<SolicitudPermisoDto>> CreateAsync(SolicitudPermisoCreateDto dto);
        Task<ResponseDto<SolicitudPermisoDto>> EditAsync(RechazarOAprobarSolicitudesEditDto dto, Guid id);
        Task<ResponseDto<SolicitudPermisoDto>> DeleteAsync(Guid id);
    }
}
