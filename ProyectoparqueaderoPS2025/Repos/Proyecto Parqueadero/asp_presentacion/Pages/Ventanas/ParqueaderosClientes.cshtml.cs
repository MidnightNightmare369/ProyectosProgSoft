using libr_dominio.Entidades;
using libr_dominio.Nucleo;
using libr_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_presentacion.Pages.Ventanas
{
    public class ParqueaderosClientesModel : PageModel
    {
        private IParqueaderosClientesPresentacion? iPresentacion = null;
        private ITipoPagosPresentacion? iTipoPagosPresentacion = null;
        private IClientesPresentacion? iClientesPresentacion = null;
        private IParqueaderosPresentacion? iParqueaderosPresentacion = null;
        private IEmpleadosPresentacion? iEmpleadosPresentacion = null;
        private ITarifasPresentacion? iTarifasPresentacion = null;

        public ParqueaderosClientesModel(IParqueaderosClientesPresentacion iPresentacion,
            IClientesPresentacion iClientesPresentacion,
            ITipoPagosPresentacion? iTipoPagosPresentacion, IParqueaderosPresentacion iParqueaderosPresentacion,
            IEmpleadosPresentacion iEmpleadosPresentacion, ITarifasPresentacion? iTarifasPresentacion)
        {
            try
            {
                this.iPresentacion = iPresentacion;
                this.iClientesPresentacion = iClientesPresentacion;
                this.iTipoPagosPresentacion = iTipoPagosPresentacion;
                this.iParqueaderosPresentacion = iParqueaderosPresentacion;
                this.iEmpleadosPresentacion = iEmpleadosPresentacion;
                this.iTarifasPresentacion = iTarifasPresentacion;
                Filtro = new ParqueaderosClientes();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }

            this.iTarifasPresentacion = iTarifasPresentacion;
        }

        public IFormFile? FormFile { get; set; }
        [BindProperty] public Enumerables.Ventanas Accion { get; set; }
        [BindProperty] public ParqueaderosClientes? Actual { get; set; }
        [BindProperty] public ParqueaderosClientes? Filtro { get; set; }
        [BindProperty] public List<ParqueaderosClientes>? Lista { get; set; }
        [BindProperty] public List<TipoPagos>? TipoPagos { get; set; }
        [BindProperty] public List<Parqueaderos>? Parqueaderos { get; set; }
        [BindProperty] public List<Clientes>? Clientes { get; set; }
        [BindProperty] public List<Empleados>? Empleados { get; set; }
        [BindProperty] public List<Tarifas>? Tarifas { get; set; }


        public virtual void OnGet() { OnPostBtRefrescar(); }

        public void OnPostBtRefrescar()
        {
            try
            {
                var variable_session = HttpContext.Session.GetString("Usuario");
                if (String.IsNullOrEmpty(variable_session))
                {
                    HttpContext.Response.Redirect("/");
                    return;
                }

                Filtro!.Posicion = Filtro!.Posicion ?? "";

                Accion = Enumerables.Ventanas.Listas;

                var task = this.iPresentacion!.PorPosicion(Filtro!);
                task.Wait();
                Lista = task.Result;
                Actual = null;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        private void CargarCombox()
        {
            try
            {
                var task = this.iClientesPresentacion!.Listar();
                task.Wait();
                Clientes = task.Result;

                var task2 = this.iTipoPagosPresentacion!.Listar();
                task2.Wait();
                TipoPagos = task2.Result;

                var task3 = this.iParqueaderosPresentacion!.Listar();
                task3.Wait();
                Parqueaderos = task3.Result;

                var task4 = this.iTarifasPresentacion!.Listar();
                task4.Wait();
                Tarifas = task4.Result;

                var task5 = this.iEmpleadosPresentacion!.Listar();
                task5.Wait();
                Empleados = task5.Result;

            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtNuevo()
        {
            try
            {
                Accion = Enumerables.Ventanas.Editar;
                Actual = new ParqueaderosClientes();
                CargarCombox();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtModificar(string data)
        {
            try
            {
                OnPostBtRefrescar();
                CargarCombox();
                Accion = Enumerables.Ventanas.Editar;
                Actual = Lista!.FirstOrDefault(x => x.Id.ToString() == data);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtGuardar()
        {
            try
            {
                Accion = Enumerables.Ventanas.Editar;

                Task<ParqueaderosClientes>? task = null;
                if (Actual!.Id == 0)
                    task = this.iPresentacion!.Guardar(Actual!)!;
                else
                    task = this.iPresentacion!.Modificar(Actual!)!;
                task.Wait();
                Actual = task.Result;
                Accion = Enumerables.Ventanas.Listas;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtBorrarVal(string data)
        {
            try
            {
                OnPostBtRefrescar();
                Accion = Enumerables.Ventanas.Borrar;
                Actual = Lista!.FirstOrDefault(x => x.Id.ToString() == data);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtBorrar()
        {
            try
            {
                var task = this.iPresentacion!.Borrar(Actual!);
                Actual = task.Result;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtCancelar()
        {
            try
            {
                Accion = Enumerables.Ventanas.Listas;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtCerrar()
        {
            try
            {
                if (Accion == Enumerables.Ventanas.Listas)
                    OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
}