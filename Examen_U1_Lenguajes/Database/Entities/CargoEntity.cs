using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examen_U1_Lenguajes.Database.Entities
{
    [Table("cargo", Schema = "dbo")]
    public class CargoEntity
    {
    [Key]
    [Column("id_cargo")]
    public Guid Id { get; set; }

    [Display(Name = "Cargo")]
    [Required(ErrorMessage = "El {0} del empleado es requerido.")]
    [StringLength(200)]
    [Column("cargo")]
    public string Cargo { get; set; }
    }
}
