using System.ComponentModel.DataAnnotations;

namespace Examen_U1_Lenguajes.Dtos.SolicitudPermisoDto
{
    public class SolicitudPermisoCreateDto
    {
        [Required]
        public Guid TipoPermisoId { get; set; }
        [Required]
        public DateTime Fechainicio { get; set; }
        [Required]
        public DateTime Fechafin { get; set; }
        [Required]
        [MinLength(10, ErrorMessage = "El motivo debe tener al menos 10 caracteres.")]
        [StringLength(250, ErrorMessage = "El motivo no puede exceder los 250 caracteres.")]
        public string Motivo { get; set; }
    }
}
