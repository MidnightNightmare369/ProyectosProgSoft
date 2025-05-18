using libr_dominio.Entidades;

namespace libr_aplicaciones.Interfaces
{
    public interface ITurnosApp
    {
        void Configurar(string StringConexion);
        List<Turnos> PorTurno(Turnos? entidad);
        List<Turnos> Listar();
        Turnos? Guardar(Turnos? entidad);
        Turnos? Modificar(Turnos? entidad);
        Turnos? Borrar(Turnos? entidad);
    }
}
