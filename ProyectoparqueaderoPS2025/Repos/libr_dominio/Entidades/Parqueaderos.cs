using System.ComponentModel.DataAnnotations.Schema;

namespace libr_dominio.Entidades
{
    public class Parqueaderos
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }

        [ForeignKey("ParqueaderosClientes")] public List<ParqueaderosClientes>? _ParqueaderosClientes { get; set; }
    }
}
