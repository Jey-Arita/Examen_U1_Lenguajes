using Examen_U1_Lenguajes.Dtos.Common;
using Examen_U1_Lenguajes.Dtos.SolicitudPermisoDto;
using Examen_U1_Lenguajes.Services;
using Examen_U1_Lenguajes.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Examen_U1_Lenguajes.Controllers
{
    [Route("api/solicitud")]
    [ApiController]
    public class SolicitudPermisoController : ControllerBase
    {
        private readonly ISolicitudPermisoService _permisoService;

        public SolicitudPermisoController(ISolicitudPermisoService permisoService)
        {
            this._permisoService = permisoService;
        }
        [HttpGet]
        public async Task<ActionResult<ResponseDto<SolicitudPermisoDto>>> GetAllSolicitudes()
        {
            var response = await _permisoService.GetSolicitudPermisoListAsync();

            return StatusCode(response.StatusCode, response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetSolicitudById(Guid id)
        {
            var response = await _permisoService.GetPermisoServiceByIdAsync(id);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<ActionResult> CreateSolicitud(SolicitudPermisoCreateDto solicitudDto)
        {
            var response = await _permisoService.CreateAsync(solicitudDto);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSolicitud(Guid id, RechazarOAprobarSolicitudesEditDto solicitudDto)
        {
            var response = await _permisoService.EditAsync(solicitudDto, id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSolicitud(Guid id)
        {
            var response = await _permisoService.DeleteAsync(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}
