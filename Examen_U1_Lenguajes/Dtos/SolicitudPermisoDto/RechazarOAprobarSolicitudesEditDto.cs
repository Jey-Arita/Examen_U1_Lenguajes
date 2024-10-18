using System.ComponentModel.DataAnnotations;

namespace Examen_U1_Lenguajes.Dtos.SolicitudPermisoDto
{
    public class RechazarOAprobarSolicitudesEditDto
    {
        public string Estado { get; set; }
        
        [StringLength(250, ErrorMessage = "La observación no puede exceder los 250 caracteres.")]
        public string Observacion { get; set; }

    }
}
