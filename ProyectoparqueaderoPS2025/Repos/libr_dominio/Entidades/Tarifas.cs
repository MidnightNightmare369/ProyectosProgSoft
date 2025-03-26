using System.ComponentModel.DataAnnotations.Schema;

namespace libr_dominio.Entidades
{
    public class Tarifas
    {
        public int Id { get; set; }
        public string? Tipo { get; set; }
        public double Valor { get; set; }

        [ForeignKey("ParqueaderosClientes")] public List<ParqueaderosClientes>? _ParqueaderosClientes { get; set; }
    }

}
