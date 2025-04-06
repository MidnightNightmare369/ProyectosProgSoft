using System.ComponentModel.DataAnnotations.Schema;

namespace libr_dominio.Entidades
{
    public class Clientes
    {
        public int Id { get; set; }
        public string? Cedula { get; set; }
        public string? Nombre { get; set; }
        public int Codigo { get; set; }
        public int Vehiculo { get; set; } 
        public int TipoCliente { get; set; }

        [ForeignKey("Vehiculo")] public Vehiculos? _Vehiculo { get; set; }
        [ForeignKey("TipoCliente")] public TipoClientes? _TipoCliente { get; set; }      
    }
}
