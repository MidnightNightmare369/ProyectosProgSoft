using libr_dominio.Entidades;

namespace libr_presentaciones.Interfaces
{
    public interface ITipoPagosPresentacion
    {
        Task<List<TipoPagos>> Listar();
        Task<List<TipoPagos>> PorTipoPago(TipoPagos? entidad);
        Task<TipoPagos?> Guardar(TipoPagos? entidad);
        Task<TipoPagos?> Modificar(TipoPagos? entidad);
        Task<TipoPagos?> Borrar(TipoPagos? entidad);
    }
}