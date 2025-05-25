using libr_presentaciones.Implementaciones; 
using libr_presentaciones.Interfaces;

namespace asp_presentacion
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
            // Presentaciones
            services.AddScoped<IAuditoriasPresentacion, AuditoriasPresentacion>();
            services.AddScoped<ICargosPresentacion, CargosPresentacion>();
            services.AddScoped<IClientesPresentacion, ClientesPresentacion>();
            services.AddScoped<IContratosPresentacion, ContratosPresentacion>();
            services.AddScoped<IEmpleadosPresentacion, EmpleadosPresentacion>();
            services.AddScoped<IParqueaderosPresentacion, ParqueaderosPresentacion>();
            services.AddScoped<IParqueaderosClientesPresentacion, ParqueaderosClientesPresentacion>();
            services.AddScoped<ITarifasPresentacion, TarifasPresentacion>();
            services.AddScoped<ITipoClientesPresentacion, TipoClientesPresentacion>();
            services.AddScoped<ITipoPagosPresentacion, TipoPagosPresentacion>();
            services.AddScoped<ITipoVehiculosPresentacion, TipoVehiculosPresentacion>();
            services.AddScoped<ITurnosPresentacion, TurnosPresentacion>();
            services.AddScoped<IVehiculosPresentacion, VehiculosPresentacion>();


            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddRazorPages();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();
            app.UseSession();
            app.Run();
        }
    }
}
