using libr_dominio.Entidades;

namespace libr_aplicaciones.Interfaces
{
    public interface ITipoPagosApp
    {
        void Configurar(string StringConexion);
        List<TipoPagos> PorTipoPago(TipoPagos? entidad);
        List<TipoPagos> Listar();
        TipoPagos? Guardar(TipoPagos? entidad);
        TipoPagos? Modificar(TipoPagos? entidad);
        TipoPagos? Borrar(TipoPagos? entidad);
    }
}
