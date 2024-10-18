using Examen_U1_Lenguajes.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class SolicitudPermisoConfiguration : IEntityTypeConfiguration<SolicitudPermisoEntitty>
{
    public void Configure(EntityTypeBuilder<SolicitudPermisoEntitty> builder)
    {
        // Clave primaria
        builder.HasKey(s => s.Solicitud);

        // Configuración de propiedades
        builder.Property(s => s.Fechainicio).IsRequired();
        builder.Property(s => s.Fechafin).IsRequired();
        builder.Property(s => s.Motivo).IsRequired().HasMaxLength(250);
        builder.Property(s => s.Estado).HasMaxLength(100);
        builder.Property(s => s.Observacion).HasMaxLength(250);

        builder.HasOne(s => s.PermisoEntity)
            .WithMany() // Cambiar según tu necesidad
            .HasForeignKey(s => s.TipoPermisoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(s => s.Usuario)
            .WithMany() // Cambiar según tu necesidad
            .HasForeignKey(s => s.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
