using Examen_U1_Lenguajes.Dtos.Common;
using Examen_U1_Lenguajes.Dtos.SolicitudPermisoDto;

namespace Examen_U1_Lenguajes.Services.Interfaces
{
    public interface ISolicitudPermisoService
    {
        Task<ResponseDto<List<SolicitudPermisoDto>>> GetSolicitudPermisoListAsync();
        Task<ResponseDto<CategoryDto>> GetPermisoServiceByIdAsync(Guid id);
        Task<ResponseDto<CategoryDto>> CreateAsync(CategoryCreateDto dto);
        Task<ResponseDto<CategoryDto>> EditAsync(CategoryEditDto dto, Guid id);
        Task<ResponseDto<CategoryDto>> DeleteAsync(Guid id);
    }
}
