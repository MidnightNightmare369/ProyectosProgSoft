using System.ComponentModel.DataAnnotations.Schema;

namespace libr_dominio.Entidades
{
    public class Turnos
    {
        public int Id { get; set; }
        public string? Turno { get; set; }
        public string? Rango { get; set; }
    }
}