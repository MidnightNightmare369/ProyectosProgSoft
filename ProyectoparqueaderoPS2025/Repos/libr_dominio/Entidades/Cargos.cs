using System.ComponentModel.DataAnnotations.Schema;

namespace libr_dominio.Entidades
{
    public class Cargos
    {
        public int Id { get; set; }
        public string? Cargo { get; set; }
    }
}
