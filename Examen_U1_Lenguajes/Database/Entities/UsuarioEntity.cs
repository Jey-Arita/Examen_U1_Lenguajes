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
        public Guid Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El {0} del empleado es requerido.")]
        [StringLength(200)]
        [Column("nombre_empleado")]
        public string Nombre { get; set; }

        [Display(Name = "Fecha_ingreso")]
        [Column("fecha_ingreso")]
        public DateTime Fecha_ingreso { get; set; }

        [StringLength(80)]
        [Column("telefono")]
        public string Telefono { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "El {0} del empleado es requerido.")]
        [StringLength(320)]
        [Column("email")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "El {0} del empleado es requerido.")]
        [StringLength(320)]
        [Column("password")]
        public string Password { get; set; }

        [Column("id_cargo")]
        public Guid CargoId { get; set; }

        [ForeignKey(nameof(CargoId))]
        public virtual CargoEntity Cargo { get; set; }

    } 
}
