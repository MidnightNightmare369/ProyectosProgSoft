using libr_dominio.Entidades;
using libr_dominio.Nucleo;
using libr_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_presentacion.Pages.Ventanas
{
    public class EmpleadosModel : PageModel
    {
        private IEmpleadosPresentacion? iPresentacion = null;
        private ICargosPresentacion? iCargosPresentacion = null;
        private IContratosPresentacion? iContratosPresentacion = null;
        private ITurnosPresentacion? iTurnosPresentacion = null;

        public EmpleadosModel(IEmpleadosPresentacion iPresentacion,
            IContratosPresentacion iContratosPresentacion,
            ICargosPresentacion? iCargosPresentacion, ITurnosPresentacion iTurnosPresentacion)
        {
            try
            {
                this.iPresentacion = iPresentacion;
                this.iContratosPresentacion = iContratosPresentacion;
                this.iCargosPresentacion = iCargosPresentacion;
                this.iTurnosPresentacion = iTurnosPresentacion;
                Filtro = new Empleados();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public IFormFile? FormFile { get; set; }
        [BindProperty] public Enumerables.Ventanas Accion { get; set; }
        [BindProperty] public Empleados? Actual { get; set; }
        [BindProperty] public Empleados? Filtro { get; set; }
        [BindProperty] public List<Empleados>? Lista { get; set; }
        [BindProperty] public List<Cargos>? Cargos { get; set; }
        [BindProperty] public List<Turnos>? Turnos { get; set; }
        [BindProperty] public List<Contratos>? Contratos { get; set; }


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

                Filtro!.Cedula = Filtro!.Cedula ?? "";

                Accion = Enumerables.Ventanas.Listas;

                var task = this.iPresentacion!.PorCedula(Filtro!);
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
                var task = this.iContratosPresentacion!.Listar();
                task.Wait();
                Contratos = task.Result;

                var task2 = this.iCargosPresentacion!.Listar();
                task2.Wait();
                Cargos = task2.Result;

                var task3 = this.iTurnosPresentacion!.Listar();
                task3.Wait();
                Turnos = task3.Result;
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
                Actual = new Empleados();
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

                Task<Empleados>? task = null;
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