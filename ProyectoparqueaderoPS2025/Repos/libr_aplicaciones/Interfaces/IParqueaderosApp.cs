using libr_dominio.Entidades;

namespace libr_aplicaciones.Interfaces
{
    public interface IParqueaderosApp
    {
        void Configurar(string StringConexion);
        List<Parqueaderos> PorNombre(Parqueaderos? entidad);
        List<Parqueaderos> Listar();
        Parqueaderos? Guardar(Parqueaderos? entidad);
        Parqueaderos? Modificar(Parqueaderos? entidad);
        Parqueaderos? Borrar(Parqueaderos? entidad);
    }
}
