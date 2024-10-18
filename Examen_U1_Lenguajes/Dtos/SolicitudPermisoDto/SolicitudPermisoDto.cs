using Examen_U1_Lenguajes.Database.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Examen_U1_Lenguajes.Dtos.SolicitudPermisoDto
{
    public class SolicitudPermisoDto
    {
        public Guid Solicitud { get; set; }
        public Guid TipoPermisoId { get; set; }
        public virtual TipoPermisoEntity PermisoEntity { get; set; }
        public DateTime Fechainicio { get; set; }
        public DateTime Fechafin { get; set; }
        public string Motivo { get; set; }
        public string Estado { get; set; }
        public string Observacion { get; set; }
    }
}
