using libr_dominio.Entidades;

namespace libr_presentaciones.Interfaces
{
    public interface IParqueaderosPresentacion
    {
        Task<List<Parqueaderos>> Listar();
        Task<List<Parqueaderos>> PorNombre(Parqueaderos? entidad);
        Task<Parqueaderos?> Guardar(Parqueaderos? entidad);
        Task<Parqueaderos?> Modificar(Parqueaderos? entidad);
        Task<Parqueaderos?> Borrar(Parqueaderos? entidad);
    }
}        