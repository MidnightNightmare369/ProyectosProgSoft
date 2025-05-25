using libr_dominio.Entidades;

namespace libr_presentaciones.Interfaces
{
    public interface ITurnosPresentacion
    {
        Task<List<Turnos>> Listar();
        Task<List<Turnos>> PorTurno(Turnos? entidad);
        Task<Turnos?> Guardar(Turnos? entidad);
        Task<Turnos?> Modificar(Turnos? entidad);
        Task<Turnos?> Borrar(Turnos? entidad);
    }
}