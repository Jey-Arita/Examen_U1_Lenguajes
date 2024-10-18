using Examen_U1_Lenguajes.Database.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Examen_U1_Lenguajes.Database
{
    public class Contexto : IdentityDbContext<IdentityUser>
    {
        public DbSet<UsuarioEntity> Empleados { get; set; }
        public DbSet<SolicitudPermisoEntitty> SolicitudesPermiso { get; set; }
        public DbSet<CargoEntity> Cargos { get; set; }
        public DbSet<TipoPermisoEntity> TipoPermisoEntities { get; set; }

        public Contexto(DbContextOptions<Contexto> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de esquema y nombres de tablas
            modelBuilder.HasDefaultSchema("security");

            modelBuilder.Entity<IdentityUser>().ToTable("users");
            modelBuilder.Entity<IdentityRole>().ToTable("roles");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("users_roles");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("users_claims");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("roles_claims");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("users_logins");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("users_tokens");

            // Configurar nombres de las tablas para las entidades de la aplicación
            modelBuilder.Entity<UsuarioEntity>().ToTable("Empleados");
            modelBuilder.Entity<SolicitudPermisoEntitty>().ToTable("SolicitudesPermiso");
            modelBuilder.Entity<CargoEntity>().ToTable("Cargos");
            modelBuilder.Entity<TipoPermisoEntity>().ToTable("TiposPermiso");

            // Configurar las relaciones con DeleteBehavior.Restrict para evitar eliminaciones en cascada no deseadas
            var entityTypes = modelBuilder.Model.GetEntityTypes();
            foreach (var type in entityTypes)
            {
                var foreignKeys = type.GetForeignKeys();
                foreach (var foreignKey in foreignKeys)
                {
                    foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
                }
            }

            // Aplicación de configuraciones adicionales de las entidades
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new SolicitudPermisoConfiguration());
            modelBuilder.ApplyConfiguration(new CargoConfiguration());
            modelBuilder.ApplyConfiguration(new TipoPermisoConfiguration());
        }

        // Método para agregar información de auditoría al guardar cambios
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                    e.State == EntityState.Added ||
                    e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                var entity = entry.Entity as BaseEntity;
                if (entity != null)
                {
                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedBy = _auditService.GetUserId(); // Registrar el usuario creador
                        entity.CreatedDate = DateTime.Now;
                    }
                    else
                    {
                        entity.UpdatedBy = _auditService.GetUserId(); // Registrar el usuario actualizador
                        entity.UpdatedDate = DateTime.Now;
                    }
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }

}
