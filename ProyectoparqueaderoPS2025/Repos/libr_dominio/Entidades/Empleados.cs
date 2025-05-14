using System.ComponentModel.DataAnnotations.Schema;

namespace libr_dominio.Entidades
{
    public class Empleados
    {
        public int Id { get; set; }
        public string? Cedula { get; set; }
        public string? Nombre { get; set; }
        public int Cargo { get; set; }
        public int Turno { get; set; }
        public int Contrato { get; set; }

        [ForeignKey("Cargo")] public Cargos? _Cargo { get; set; }        
        [ForeignKey("Turno")] public Turnos? _Turno { get; set; }
        [ForeignKey("Contrato")] public Contratos? _Contrato { get; set; }
    }    
}
