using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Examen_U1_Lenguajes.Database.Entities
{
    [Table("usuarios", Schema = "dbo")]
    public class UsuarioEntity
    {
        [Key]
        [Column("id_usuario")]
        public Guid Id_usuario { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El {0} del empleado es requerido.")]
        [StringLength(200)]
        [Column("nombre_empleado")]
        public string Nombre { get; set; }

        [Display(Name = "Fecha_ingreso")]
        [Column("fecha_ingreso")]
        public DateTime Fecha_ingreso { get; set; }

        [Display(Name = "Telefono")]
        [Required(ErrorMessage = "El {0} del empleado es requerido.")]
        [StringLength(80)]
        [Column("telefono")]
        public string Telefono { get; set; }

        [Display(Name = "Telefono")]
        [Required(ErrorMessage = "El {0} del empleado es requerido.")]
        [StringLength(80)]
        [Column("telefono")]
        public string Telefono { get; set; }

    }
}
