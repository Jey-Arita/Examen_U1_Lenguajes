using Examen_U1_Lenguajes.Constants;
using Examen_U1_Lenguajes.Database.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Examen_U1_Lenguajes.Database
{
    public class Seeder
    {
        public static async Task LoadDataAsync(
            Contexto context,
            ILoggerFactory loggerFactory,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            try
            {
                await LoadRolesAndUSersAsync(userManager, roleManager, loggerFactory);
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<Seeder>();
                logger.LogError(e, "Error inicializando la data del API");
            }
        }

        // TODO: Seed de usuarios
        public static async Task LoadRolesAndUSersAsync(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ILoggerFactory loggerFactory)
        {
            try
            {
                if (!await roleManager.Roles.AnyAsync())
                {
                    //Evitamos tener los string quemados
                    await roleManager.CreateAsync(new IdentityRole(RolesConstant.ADMIN));
                    await roleManager.CreateAsync(new IdentityRole(RolesConstant.EMPLEADO));
                }

                if (!await userManager.Users.AnyAsync())
                {
                    var userAdmin = new IdentityUser
                    {
                        Email = "admin@blogunah.edu",
                        UserName = "admin@blogunah.edu",
                    };

                    var userEmpleado = new IdentityUser
                    {
                        Email = "empleado@blogunah.edu",
                        UserName = "empleado@blogunah.edu",
                    };

                    await userManager.CreateAsync(userAdmin, "Temporal01*");
                    await userManager.CreateAsync(userEmpleado, "Temporal01*");
              

                    await userManager.AddToRoleAsync(userAdmin, RolesConstant.ADMIN);
                    await userManager.AddToRoleAsync(userEmpleado, RolesConstant.EMPLEADO);
                }

            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<Seeder>();
                logger.LogError(e.Message);
            }
        }

        public static async Task LoadTipoPermisoAsync(ILoggerFactory loggerFactory, Contexto context)
        {
            try
            {
                var jsonFilePath = "SeedData/TipoPermiso.json";
                var jsonContent = await File.ReadAllTextAsync(jsonFilePath);
                var tipoPermisos = JsonConvert.DeserializeObject<List<TipoPermisoEntity>>(jsonContent);

            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<Seeder>();
                logger.LogError(e, "Error al ejecutar el Seed de Tipo de Permiso");
            }
        }
    }
}
