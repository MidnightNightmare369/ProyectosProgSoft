using System.ComponentModel.DataAnnotations.Schema;


namespace libr_dominio.Entidades
{
    public class TipoPagos
    {
        public int Id { get; set; }
        public string? TipoPago { get; set; }
    }
}