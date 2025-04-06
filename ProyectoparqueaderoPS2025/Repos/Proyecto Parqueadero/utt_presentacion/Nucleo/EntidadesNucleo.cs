using libr_dominio.Entidades;

namespace utt_presentacion.Nucleo
{
    public class EntidadesNucleo
    {

        public static TipoPagos? TipoPagos()
        {
            var entidad = new TipoPagos();
            entidad.TipoPago = "Efectivo-TEST-" + DateTime.Now.ToString("yyyyMMddHHmmss");
            return entidad;
        }

        public static TipoClientes? TipoClientes()
        {
            var entidad = new TipoClientes();
            entidad.TipoCliente = "Regular-TEST-" + DateTime.Now.ToString("yyyyMMddHHmmss");
            return entidad;
        }

        public static TipoVehiculos? TipoVehiculos()
        {
            var entidad = new TipoVehiculos();
            entidad.TipoVehiculo = "TEST-" + DateTime.Now.ToString("yyyyMMddHHmmss");            
            return entidad;
        }

        public static Vehiculos? Vehiculos()
        {
            var entidad = new Vehiculos();
            entidad.Placa = "TEST-" + DateTime.Now.ToString("yyyyMMddHHmmss");
            entidad.TipoVehiculo = 1;
            return entidad;
        }

        public static Clientes? Clientes()
        {
            var entidad = new Clientes();
            entidad.Cedula = "TEST-" + DateTime.Now.ToString("yyyyMMddHHmmss");
            entidad.Nombre = "Cliente-Prueba";
            entidad.Vehiculo = 1;
            entidad.TipoCliente = 1;
            entidad.Codigo = 100;
            return entidad;
        }

        public static Tarifas? Tarifas()
        {
            var entidad = new Tarifas();
            entidad.Tipo = "TEST-" + "MotoR";
            entidad.Valor = 9000;
            return entidad;
        }

        public static Parqueaderos? Parqueaderos()
        {
            var entidad = new Parqueaderos();
            entidad.Nombre = "Parqueadero-Prueba-" + DateTime.Now.ToString("yyyyMMddHHmmss");
            return entidad;
        }

        public static ParqueaderosClientes? ParqueaderosClientes()
        {
            var entidad = new ParqueaderosClientes();
            entidad.Tiempo = 2; 
            entidad.Posicion = "A1-TEST-" + DateTime.Now.ToString("yyyyMMddHHmmss");
            entidad.Total = 7500;
            entidad.Tarifa = 1;
            entidad.TipoPago = 1;
            entidad.Cliente = 1;
            entidad.Parqueadero = 1;
            return entidad;
        }

    }
}