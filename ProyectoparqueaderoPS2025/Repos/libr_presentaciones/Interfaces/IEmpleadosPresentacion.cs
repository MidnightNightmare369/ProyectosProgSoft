using libr_dominio.Entidades;

namespace libr_presentaciones.Interfaces
{
    public interface IEmpleadosPresentacion
    {
        Task<List<Empleados>> Listar();
        Task<List<Empleados>> PorCedula(Empleados? entidad);
        Task<Empleados?> Guardar(Empleados? entidad);
        Task<Empleados?> Modificar(Empleados? entidad);
        Task<Empleados?> Borrar(Empleados? entidad);
    }
}