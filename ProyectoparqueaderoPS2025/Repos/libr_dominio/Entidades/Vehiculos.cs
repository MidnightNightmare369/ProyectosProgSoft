using System.ComponentModel.DataAnnotations.Schema;

namespace libr_dominio.Entidades
{
    public class Vehiculos
    {
        public int Id { get; set; }
        public string? Placa { get; set; }
        public int TipoVehiculo { get; set; }

        [ForeignKey("TipoVehiculo")] public TipoVehiculos? _TipoVehiculo { get; set; }
        public List<Clientes>? _Clientes { get; set; }
    }
}
