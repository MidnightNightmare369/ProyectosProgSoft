using libr_dominio.Entidades;

namespace libr_presentaciones.Interfaces
{
    public interface IContratosPresentacion
    {
        Task<List<Contratos>> Listar();
        Task<List<Contratos>> PorReferencia(Contratos? entidad);
        Task<Contratos?> Guardar(Contratos? entidad);
        Task<Contratos?> Modificar(Contratos? entidad);
        Task<Contratos?> Borrar(Contratos? entidad);
    }
}