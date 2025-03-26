using System.ComponentModel.DataAnnotations.Schema;

namespace libr_dominio.Entidades
{
    public class TipoClientes
    {
        public int Id { get; set; }
        public string? TipoCliente { get; set; }

        [ForeignKey("Clientes")] public List<Clientes>? _Clientes { get; set; }
    }

}
