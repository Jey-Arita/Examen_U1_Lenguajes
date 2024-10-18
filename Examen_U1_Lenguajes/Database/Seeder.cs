using Examen_U1_Lenguajes.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
                    await roleManager.CreateAsync(new IdentityRole(RolesContant.ADMIN));
                    await roleManager.CreateAsync(new IdentityRole(RolesContant.EMPLEADO));
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

                    await userManager.AddToRoleAsync(userAdmin, RolesContant.ADMIN);
                    await userManager.AddToRoleAsync(userEmpleado, RolesContant.EMPLEADO);
                }

            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<Contexto>();
                logger.LogError(e.Message);
            }
        }

    }
}
