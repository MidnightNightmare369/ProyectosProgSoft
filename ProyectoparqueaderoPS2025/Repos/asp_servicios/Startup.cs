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
            services.AddScoped<ITipoVehiculosApp, TipoVehiculosApp>();
            services.AddScoped<IVehiculosApp, VehiculosApp>();
            services.AddScoped<IAuditoriasApp, AuditoriasApp>();

            // Controladores
            services.AddScoped<TokenController, TokenController>();
            services.AddScoped<CargosController, CargosController>();
            services.AddScoped<ContratosController, ContratosController>();
            services.AddScoped<EmpleadosController, EmpleadosController>();
            services.AddScoped<ParqueaderosClientesController, ParqueaderosClientesController>();
            services.AddScoped<ParqueaderosController, ParqueaderosController>();
            services.AddScoped<TarifasController, TarifasController>();
            services.AddScoped<TipoClientesController, TipoClientesController>();
            services.AddScoped<TipoPagosController, TipoPagosController>();
            services.AddScoped<TipoVehiculosController, TipoVehiculosController>();
            services.AddScoped<TurnosController, TurnosController>();
            services.AddScoped<VehiculosController, VehiculosController>();
            services.AddScoped<ClientesController, ClientesController>();
            services.AddScoped<AuditoriasController, AuditoriasController>();

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
