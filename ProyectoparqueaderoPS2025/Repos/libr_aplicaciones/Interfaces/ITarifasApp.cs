using libr_dominio.Entidades;

namespace libr_aplicaciones.Interfaces
{
    public interface ITarifasApp
    {
        void Configurar(string StringConexion);
        List<Tarifas> PorTipo(Tarifas? entidad);
        List<Tarifas> Listar();
        Tarifas? Guardar(Tarifas? entidad);
        Tarifas? Modificar(Tarifas? entidad);
        Tarifas? Borrar(Tarifas? entidad);
    }
}
