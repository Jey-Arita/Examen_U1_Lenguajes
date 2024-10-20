﻿using Examen_U1_Lenguajes.Database.Entities;
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
        
    }
}
