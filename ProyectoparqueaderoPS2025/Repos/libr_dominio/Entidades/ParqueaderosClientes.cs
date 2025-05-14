using System.ComponentModel.DataAnnotations.Schema;

namespace libr_dominio.Entidades
{
    public class ParqueaderosClientes
    {
        public int Id { get; set; }
        public decimal Tiempo { get; set; }
        public string? Posicion { get; set; }
        public decimal Total { get; set; }
        public int Tarifa { get; set; }
        public int TipoPago { get; set; }
        public int Cliente { get; set; }
        public int Parqueadero { get; set; }
        public int Empleado { get; set; }

        [ForeignKey("Tarifa")] public Tarifas? _Tarifa { get; set; }
        [ForeignKey("TipoPago")] public TipoPagos? _TipoPago { get; set; }
        [ForeignKey("Cliente")] public Clientes? _Cliente { get; set; }
        [ForeignKey("Parqueadero")] public Parqueaderos? _Parqueadero { get; set; }
        [ForeignKey("Empleado")] public Empleados? _Empleado { get; set; }
    }
}
