using libr_dominio.Entidades;

namespace libr_aplicaciones.Interfaces
{
    public interface ITipoVehiculosApp
    {
        void Configurar(string StringConexion);
        List<TipoVehiculos> PorTipoVehiculo(TipoVehiculos? entidad);
        List<TipoVehiculos> Listar();
        TipoVehiculos? Guardar(TipoVehiculos? entidad);
        TipoVehiculos? Modificar(TipoVehiculos? entidad);
        TipoVehiculos? Borrar(TipoVehiculos? entidad);
    }
}
