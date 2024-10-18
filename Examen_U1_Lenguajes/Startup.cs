using Examen_U1_Lenguajes.Database;
using Examen_U1_Lenguajes.Services;
using Examen_U1_Lenguajes.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Examen_U1_Lenguajes
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddHttpContextAccessor();

            // Solo agregar DbContext una vez
            services.AddDbContext<Contexto>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Configuración de AutoMapper
            services.AddAutoMapper(typeof(Startup)); // O especifica el perfil de AutoMapper

            // Otras configuraciones de servicios
            services.AddTransient<ISolicitudPermisoService, SolicitudPermisoServices>();
            services.AddTransient<IAuthService, AuthService>();
            // ... otros servicios
            services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<Contexto>()
            .AddDefaultTokenProviders();


            // Agregar servicios personalizados
            services.AddTransient<ISolicitudPermisoService, SolicitudPermisoServices>();

            // Configuración de autenticación
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                };
            });

            // Configuración de CORS
            services.AddCors(opt =>
            {
                var allowURLS = Configuration.GetSection("AllowURLS").Get<string[]>();

                opt.AddPolicy("CorsPolicy", builder => builder
                .WithOrigins(allowURLS)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
