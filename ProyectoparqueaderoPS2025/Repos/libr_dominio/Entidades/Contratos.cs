using System.ComponentModel.DataAnnotations.Schema;

namespace libr_dominio.Entidades
{
    public class Contratos
    {
        public int Id { get; set; }
        public string? Referencia { get; set; }
        public string? FechaInicio { get; set; }
        public string? FechaTerminacion { get; set; }        
    }
}
