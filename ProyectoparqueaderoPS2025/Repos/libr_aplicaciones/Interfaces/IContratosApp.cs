using libr_dominio.Entidades;

namespace libr_aplicaciones.Interfaces
{
    public interface IContratosApp
    {
        void Configurar(string StringConexion);
        List<Contratos> PorReferencia(Contratos? entidad);
        List<Contratos> Listar();
        Contratos? Guardar(Contratos? entidad);
        Contratos? Modificar(Contratos? entidad);
        Contratos? Borrar(Contratos? entidad);
    }
}
