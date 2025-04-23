using libr_dominio.Entidades;

namespace libr_aplicaciones.Interfaces
{
    public interface ITipoClientesApp
    {
        void Configurar(string StringConexion);
        List<TipoClientes> PorTipoCliente(TipoClientes? entidad);
        List<TipoClientes> Listar();
        TipoClientes? Guardar(TipoClientes? entidad);
        TipoClientes? Modificar(TipoClientes? entidad);
        TipoClientes? Borrar(TipoClientes? entidad);
    }
}
