using libr_dominio.Entidades;

namespace libr_aplicaciones.Interfaces
{
    public interface IVehiculosApp
    {
        void Configurar(string StringConexion);
        List<Vehiculos> PorPlaca(Vehiculos? entidad);
        List<Vehiculos> Listar();
        Vehiculos? Guardar(Vehiculos? entidad);
        Vehiculos? Modificar(Vehiculos? entidad);
        Vehiculos? Borrar(Vehiculos? entidad);
    }
}
