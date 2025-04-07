using libr_dominio.Entidades;

namespace libr_aplicaciones.Interfaces
{
    public interface IParqueaderosClientesApp
    {
        void Configurar(string StringConexion);
        List<ParqueaderosClientes> PorPosicion(ParqueaderosClientes? entidad);
        List<ParqueaderosClientes> Listar();
        ParqueaderosClientes? Guardar(ParqueaderosClientes? entidad);
        ParqueaderosClientes? Modificar(ParqueaderosClientes? entidad);
        ParqueaderosClientes? Borrar(ParqueaderosClientes? entidad);
    }
}