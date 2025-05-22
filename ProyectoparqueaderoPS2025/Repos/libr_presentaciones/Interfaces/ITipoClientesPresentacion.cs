using libr_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface ITipoClientesPresentacion
    {
        Task<List<TipoClientes>> Listar();
        Task<List<TipoClientes>> PorTipoCliente(TipoClientes? entidad);
        Task<TipoClientes?> Guardar(TipoClientes? entidad);
        Task<TipoClientes?> Modificar(TipoClientes? entidad);
        Task<TipoClientes?> Borrar(TipoClientes? entidad);
    }
}