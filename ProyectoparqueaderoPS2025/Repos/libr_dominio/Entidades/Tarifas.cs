using System.ComponentModel.DataAnnotations.Schema;

namespace libr_dominio.Entidades
{
    public class Tarifas
    {
        public int Id { get; set; }
        public string? Tipo { get; set; }
        public decimal Valor { get; set; }

    }
}
