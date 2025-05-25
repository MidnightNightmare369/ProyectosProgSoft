using libr_dominio.Entidades;

namespace libr_presentaciones.Interfaces
{
    public interface ITipoVehiculosPresentacion
    {
        Task<List<TipoVehiculos>> Listar();
        Task<List<TipoVehiculos>> PorTipoVehiculo(TipoVehiculos? entidad);
        Task<TipoVehiculos?> Guardar(TipoVehiculos? entidad);
        Task<TipoVehiculos?> Modificar(TipoVehiculos ? entidad);
        Task<TipoVehiculos?> Borrar(TipoVehiculos? entidad);
    }
}