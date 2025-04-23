using libr_dominio.Entidades;

namespace libr_aplicaciones.Interfaces
{
    public interface IClientesApp
    {
        void Configurar(string StringConexion);
        List<Clientes> PorCedula(Clientes? entidad);
        List<Clientes> Listar();
        Clientes? Guardar(Clientes? entidad);
        Clientes? Modificar(Clientes? entidad);
        Clientes? Borrar(Clientes? entidad);
    }
}
