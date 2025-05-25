using libr_dominio.Entidades;

namespace libr_presentaciones.Interfaces
{
    public interface IParqueaderosClientesPresentacion
    {
        Task<List<ParqueaderosClientes>> Listar();
        Task<List<ParqueaderosClientes>> PorPosicion(ParqueaderosClientes? entidad);
        Task<ParqueaderosClientes?> Guardar(ParqueaderosClientes? entidad);
        Task<ParqueaderosClientes?> Modificar(ParqueaderosClientes? entidad);
        Task<ParqueaderosClientes?> Borrar(ParqueaderosClientes? entidad);
    }
}