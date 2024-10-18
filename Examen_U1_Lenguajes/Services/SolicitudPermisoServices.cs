using AutoMapper;
using Examen_U1_Lenguajes.Database;
using Examen_U1_Lenguajes.Database.Entities;
using Examen_U1_Lenguajes.Dtos.Common;
using Examen_U1_Lenguajes.Dtos.SolicitudPermisoDto;
using Examen_U1_Lenguajes.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;

namespace Examen_U1_Lenguajes.Services
{
    
    public class SolicitudPermisoServices : ISolicitudPermisoService
    {
        private readonly Contexto _contexto;
        private readonly IMapper _autoMapper;

        public SolicitudPermisoServices(Contexto contexto, IMapper autoMapper)
        {
            this._contexto = contexto;
            this._autoMapper = autoMapper;
        }
        public async Task<ResponseDto<List<SolicitudPermisoDto>>> GetSolicitudPermisoListAsync()
        {
            var solicitud = await _contexto.SolicitudesPermiso.ToListAsync();
            var solicitudDto = _autoMapper.Map<List<SolicitudPermisoDto>>(solicitud);
            return new ResponseDto<List<SolicitudPermisoDto>>
            {
                StatusCode = 200,
                Status = true,
                Message = "Listado de registro obtenido correctamente.",
                Data = solicitudDto
            };
        }
        public async Task<ResponseDto<SolicitudPermisoDto>> GetPermisoServiceByIdAsync(Guid id)
        {
            var solicitudEntity = await _contexto.SolicitudesPermiso.FirstOrDefaultAsync();
            if (solicitudEntity == null)
            {
                return new ResponseDto<SolicitudPermisoDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "No se encontro el registro"
                };
            }
            var solicitudDto = _autoMapper.Map<SolicitudPermisoDto>(solicitudEntity);
            return new ResponseDto<SolicitudPermisoDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Resgistro encontrado",
                Data = solicitudDto
            };
        }
        public async Task<ResponseDto<SolicitudPermisoDto>> CreateAsync(SolicitudPermisoCreateDto dto)
        {
            var solicituEntitry = _autoMapper.Map<SolicitudPermisoEntitty>(dto);
            _contexto.SolicitudesPermiso.Add(solicituEntitry);
            
            await _contexto.SaveChangesAsync();
           
            var solicitudDto = _autoMapper.Map<SolicitudPermisoDto>(solicituEntitry);
            return new ResponseDto<SolicitudPermisoDto>
            {
                StatusCode = 201,
                Status = true,
                Message = "Se a Creado una Solicitud",
                Data = solicitudDto
            };
        }
        public async Task<ResponseDto<SolicitudPermisoDto>> EditAsync(RechazarOAprobarSolicitudesEditDto dto, Guid id)
        {
            var solicitudEntity = await _contexto.SolicitudesPermiso.FirstOrDefaultAsync(s => s.Solicitud == id);

            if (solicitudEntity == null)
            {
                return new ResponseDto<SolicitudPermisoDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "Solicitud no encontrada."
                };
            }

            solicitudEntity.Estado = dto.Estado;
            solicitudEntity.Observacion = dto.Observacion;

            _contexto.SolicitudesPermiso.Update(solicitudEntity);
            await _contexto.SaveChangesAsync();

            var solicitudDto = _autoMapper.Map<SolicitudPermisoDto>(solicitudEntity);

            return new ResponseDto<SolicitudPermisoDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Solicitud actualizada correctamente.",
                Data = solicitudDto
            };
        }
        public async Task<ResponseDto<SolicitudPermisoDto>> DeleteAsync(Guid id)
        {
            var solicitudEntity = await _contexto.SolicitudesPermiso.FirstOrDefaultAsync(s => s.Solicitud == id);

            if (solicitudEntity == null)
            {
                return new ResponseDto<SolicitudPermisoDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "Solicitud no encontrada."
                };
            }
            _contexto.SolicitudesPermiso.Remove(solicitudEntity);
            await _contexto.SaveChangesAsync();

            return new ResponseDto<SolicitudPermisoDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Solicitud eliminada correctamente."
            };
        }
    }
}
