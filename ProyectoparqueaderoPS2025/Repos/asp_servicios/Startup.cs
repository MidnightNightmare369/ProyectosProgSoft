using asp_servicios.Controllers;
using libr_aplicaciones.Implementaciones;
using libr_aplicaciones.Interfaces;
using libr_repositorios;
using libr_repositorios.Implementaciones;
using libr_repositorios.Interfaces;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace asp_servicios
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration? Configuration { set; get; }

        public void ConfigureServices(WebApplicationBuilder builder, IServiceCollection services)
        {
            services.Configure<KestrelServerOptions>(x =>
            {
                x.AllowSynchronousIO = true;
            });
            services.Configure<IISServerOptions>(x =>
            {
                x.AllowSynchronousIO = true;
            });
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            //services.AddSwaggerGen();

            // Repositorios
            services.AddScoped<IConexion, Conexion>();

            // Aplicaciones
            services.AddScoped<IParqueaderosClientesApp, ParqueaderosClientesApp>();
            services.AddScoped<IClientesApp, ClientesApp>();
            services.AddScoped<IContratosApp, ContratosApp>();
            services.AddScoped<ICargosApp, CargosApp>();
            services.AddScoped<ITurnosApp, TurnosApp>();
            services.AddScoped<IEmpleadosApp, EmpleadosApp>();
            services.AddScoped<IParqueaderosApp, ParqueaderosApp>();
            services.AddScoped<ITarifasApp, TarifasApp>();
            services.AddScoped<ITipoClientesApp, TipoClientesApp>();
            services.AddScoped<ITipoPagosApp, TipoPagosApp>();
            services.AddScoped<ITipoPagosApp, TipoPagosApp>();
            services.AddScoped<IVehiculosApp, VehiculosApp>();

            // Controladores
            services.AddScoped<TokenController, TokenController>();
            //Intentar añador controlador TestController: services.AddScoped<TestController, TestController>();

            services.AddCors(o => o.AddDefaultPolicy(b => b.AllowAnyOrigin()));
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseSwagger();
                //app.UseSwaggerUI();
            }
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.UseCors();
        }
    }
}
