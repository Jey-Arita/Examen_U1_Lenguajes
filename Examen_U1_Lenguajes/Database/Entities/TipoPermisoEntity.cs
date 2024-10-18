using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examen_U1_Lenguajes.Database.Entities
{
    public class TipoPermisoEntity
    {
        [Key]
        [Column("id_permiso")]
        public Guid IdPermiso { get; set; }

        [Display(Name = "permiso")]
        [StringLength(200)]
        [Column("tipo_permiso")]
        public string TipoPermiso { get; set; }
    }
}
