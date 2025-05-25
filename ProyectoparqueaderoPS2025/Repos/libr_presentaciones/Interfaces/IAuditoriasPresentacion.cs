using libr_dominio.Entidades;

namespace libr_presentaciones.Interfaces
{
    public interface IAuditoriasPresentacion
    {
        Task<List<Auditorias>> Listar();
        Task<List<Auditorias>> PorTipoModificacion(Auditorias? entidad);
        Task<Auditorias?> Guardar(Auditorias? entidad);
        Task<Auditorias?> Modificar(Auditorias? entidad);
        Task<Auditorias?> Borrar(Auditorias? entidad);
    }
}