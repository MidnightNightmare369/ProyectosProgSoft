using libr_dominio.Entidades;

namespace libr_presentaciones.Interfaces
{
    public interface ICargosPresentacion
    {
        Task<List<Cargos>> Listar();
        Task<List<Cargos>> PorCargo(Cargos? entidad);
        Task<Cargos?> Guardar(Cargos? entidad);
        Task<Cargos?> Modificar(Cargos? entidad);
        Task<Cargos?> Borrar(Cargos? entidad);
    }
}