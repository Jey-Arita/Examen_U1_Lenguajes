using Examen_U1_Lenguajes.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CargoConfiguration : IEntityTypeConfiguration<CargoEntity>
{
    public void Configure(EntityTypeBuilder<CargoEntity> builder)
    {
        // Configuración de la clave primaria
        builder.HasKey(c => c.Id);

        // Configuración de propiedades
        builder.Property(c => c.Cargo)
            .IsRequired()
            .HasMaxLength(200);
    }
}
