using System.ComponentModel.DataAnnotations.Schema;

namespace libr_dominio.Entidades
{
    public class TipoClientes
    {
        public int Id { get; set; }
        public string? TipoCliente { get; set; }

    }
}
