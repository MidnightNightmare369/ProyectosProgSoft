using libr_dominio.Entidades;

namespace libr_presentaciones.Interfaces
{
    public interface ITarifasPresentacion
    {
        Task<List<Tarifas>> Listar();
        Task<List<Tarifas>> PorTipo(Tarifas? entidad);
        Task<Tarifas?> Guardar(Tarifas? entidad);
        Task<Tarifas?> Modificar(Tarifas? entidad);
        Task<Tarifas?> Borrar(Tarifas? entidad);
    }
}