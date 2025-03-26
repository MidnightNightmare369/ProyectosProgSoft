using System.ComponentModel.DataAnnotations.Schema;

namespace libr_dominio.Entidades
{
    public class TipoVehiculos{
        public int Id { get; set; }
        public string? TipoVehiculo { get; set; }

        [ForeignKey("Vehiculos")] public List<Vehiculos>? _Vehiculos { get; set; }
    }

}
