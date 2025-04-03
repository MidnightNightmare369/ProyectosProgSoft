using libr_dominio.Entidades;
using libr_repositorios.Implementaciones;
using Microsoft.EntityFrameworkCore;

namespace Cns_presentacion.Repositorios
{
    public class RepositorioParqueaderos
    {
        private string string_conexion = "server=ALVARO-PC\\SQLEXPRESS;database=db_parqueadero;Integrated Security=True;TrustServerCertificate=true;";

        public void Select()
        {
            Console.WriteLine("MOSTRAR DATOS");

            var conexion = new Conexion();
            conexion.StringConexion = this.string_conexion;

            var lista = conexion.ParqueaderosClientes!.ToList();

            foreach (var elemento in lista)
            {
                Console.WriteLine(elemento.Id.ToString() + "|" +
                    elemento.Tiempo.ToString() + "|" +
                    elemento.Posicion + "|" +
                    elemento.Total.ToString() + "|" +
                    elemento.Tarifa.ToString() + "|" +
                    elemento.TipoPago.ToString() + "|" +
                    elemento.Cliente.ToString() + "|" +
                    elemento.Parqueadero.ToString() + "|" 
                    );
            }
            

            Console.WriteLine(Environment.NewLine);
        }

        public void Insert()
        {
            var conexion = new Conexion();
            conexion.StringConexion = this.string_conexion;

            var entidad = new ParqueaderosClientes();
            entidad.Tiempo = 2.5m;
            entidad.Posicion = "A1PRUEBA";
            entidad.Total = 7500.0m;
            entidad.Tarifa = 1;     
            entidad.TipoPago = 1;
            entidad.Cliente = 1;  
            entidad.Parqueadero = 1; 

            conexion.ParqueaderosClientes!.Add(entidad);
            conexion.SaveChanges();
        }

        public void Update()
        {
            var conexion = new Conexion();
            conexion.StringConexion = this.string_conexion;

            var entidad = conexion.ParqueaderosClientes!.FirstOrDefault(x => x.Posicion == "A1PRUEBA");
            if (entidad == null)
                return;

            entidad.Total = entidad.Tiempo * entidad.Tarifa;

            var entry = conexion.Entry<ParqueaderosClientes>(entidad);
            entry.State = EntityState.Modified;
            conexion.SaveChanges();
        }

        public void Delete()
        {
            var conexion = new Conexion();
            conexion.StringConexion = this.string_conexion;

            var entidad = conexion.ParqueaderosClientes!.FirstOrDefault(x => x.Posicion == "A1PRUEBA");

            if (entidad == null)
                return;

            conexion.ParqueaderosClientes!.Remove(entidad);
            conexion.SaveChanges();
        }

    }
}