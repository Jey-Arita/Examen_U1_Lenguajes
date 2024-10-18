using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Examen_U1_Lenguajes.Database.Entities
{
    [Table("solicitud_permiso", Schema = "dbo")]
    public class SolicitudPermisoEntitty
    {
        [Key]
        [Column("id_solicitud")]
        public Guid Solicitud { get; set; }

        [Column("cargo_id")]
        public Guid TipoPermisoId { get; set; }

        [ForeignKey(nameof(TipoPermisoId))]
        public virtual TipoPermisoEntity PermisoEntity { get; set; }

        [Display(Name = "Fecha_inicio")]
        [Column("fecha_inicio")]
        public DateTime Fechainicio { get; set; }

        [Display(Name = "Fecha_fin")]
        [Column("fecha_fin")]
        public DateTime Fechafin { get; set; }

        [Display(Name = "Motivo")]
        [MinLength(10, ErrorMessage = "La {0} debe tener al menos {1} caracteres.")]
        [StringLength(250)]
        [Column("motivo")]
        public string Motivo { get; set; }

        [Column("estado")]
        public string Estado { get; set; }

        [Display(Name = "Observacion")]
        [MinLength(10, ErrorMessage = "La {0} debe tener al menos {1} caracteres.")]
        [StringLength(250)]
        [Column("observacion")]
        public string Observacion { get; set; }
        
        [Column("usuario_id")]
        public Guid UsuarioId { get; set; }

        [ForeignKey(nameof(UsuarioId))]
        public virtual UsuarioEntity Usuario { get; set; }
    }
}
