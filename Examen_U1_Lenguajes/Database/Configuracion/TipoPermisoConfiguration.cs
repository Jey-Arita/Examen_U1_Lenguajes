using Examen_U1_Lenguajes.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TipoPermisoConfiguration : IEntityTypeConfiguration<TipoPermisoEntity>
{
    public void Configure(EntityTypeBuilder<TipoPermisoEntity> builder)
    {
        // Configuración de la clave primaria
        builder.HasKey(t => t.IdPermiso);

        // Configuración de propiedades
        builder.Property(t => t.TipoPermiso)
            .HasMaxLength(200);
    }
}
