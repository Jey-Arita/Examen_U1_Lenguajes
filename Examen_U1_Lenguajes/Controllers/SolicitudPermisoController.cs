using Examen_U1_Lenguajes.Dtos.Common;
using Examen_U1_Lenguajes.Dtos.SolicitudPermisoDto;
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

            return StatusCode(response.StatusCode, new
            {
                response.Status,
                response.Message,
                response.Data
            });
        }

    }
}
