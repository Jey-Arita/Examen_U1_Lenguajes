using Examen_U1_Lenguajes.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UsuarioConfiguration : IEntityTypeConfiguration<UsuarioEntity>
{
    public void Configure(EntityTypeBuilder<UsuarioEntity> builder)
    {
        // Configuración de la clave primaria
        builder.HasKey(u => u.Id);

        // Configuración de propiedades
        builder.Property(u => u.Nombre)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(u => u.Fecha_ingreso)
            .IsRequired();

        builder.Property(u => u.Telefono)
            .HasMaxLength(80);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(320);

        builder.Property(u => u.Password)
            .IsRequired()
            .HasMaxLength(320);

        // Configurar relación con Cargo
        builder.HasOne(u => u.Cargo)
            .WithMany()
            .HasForeignKey(u => u.CargoId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
