using libr_dominio.Entidades;

namespace libr_aplicaciones.Interfaces
{
    public interface IAuditoriasApp
    {
        void Configurar(string StringConexion);
        List<Auditorias> PorTipoModificacion(Auditorias? entidad);
        List<Auditorias> Listar();
        Auditorias? Guardar(Auditorias? entidad);
        Auditorias? Modificar(Auditorias? entidad);
        Auditorias? Borrar(Auditorias? entidad);
    }
}
