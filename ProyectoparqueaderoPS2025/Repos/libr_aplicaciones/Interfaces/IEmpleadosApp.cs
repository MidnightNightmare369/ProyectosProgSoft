using libr_dominio.Entidades;

namespace libr_aplicaciones.Interfaces
{
    public interface IEmpleadosApp
    {
        void Configurar(string StringConexion);
        List<Empleados> PorCedula(Empleados? entidad);
        List<Empleados> Listar();
        Empleados? Guardar(Empleados? entidad);
        Empleados? Modificar(Empleados? entidad);
        Empleados? Borrar(Empleados? entidad);
    }
}
