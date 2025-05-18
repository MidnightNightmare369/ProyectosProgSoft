using libr_dominio.Entidades;

namespace libr_aplicaciones.Interfaces
{
    public interface ICargosApp
    {
        void Configurar(string StringConexion);
        List<Cargos> PorCargo(Cargos? entidad);
        List<Cargos> Listar();
        Cargos? Guardar(Cargos? entidad);
        Cargos? Modificar(Cargos? entidad);
        Cargos? Borrar(Cargos? entidad);
    }
}
