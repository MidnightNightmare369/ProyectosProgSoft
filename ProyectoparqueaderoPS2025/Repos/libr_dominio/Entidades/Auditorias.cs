using System.ComponentModel.DataAnnotations.Schema;

namespace libr_dominio.Entidades
{
    public class Auditorias
    {
        public int Id { get; set; }
        public string? Clase { get; set; }
        public int IdModificado { get; set; }
        public string? TipoModificacion { get; set; }
        public DateTime Fecha { get; set; }
    }
}
