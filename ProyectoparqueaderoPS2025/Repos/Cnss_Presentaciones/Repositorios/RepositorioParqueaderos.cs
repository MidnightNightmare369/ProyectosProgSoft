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
            conexion.StringConnection = this.string_conexion;

            /*var lista = conexion.ParqueaderosClientes!.ToList();

            foreach (var elemento in lista)
            {
                Console.WriteLine(elemento.Id.ToString() + "|" +
                    elemento.Tiempo.ToString() + "|" +
                    elemento.Posicion + "|" +
                    elemento.Total.ToString() + "|" +
                    elemento.Tarifa.ToString() + "|" +
                    elemento.TipoPago.ToString() + "|" +
                    elemento.Cliente.ToString() + "|" +
                    elemento.Parqueadero.ToString());
            }
            */
            var lista = conexion.Vehiculos!.ToList();

            foreach (var elemento in lista)
            {
                Console.WriteLine(elemento.Id.ToString() + "|" +
                    elemento.Placa + "|" +
                    elemento.TipoVehiculo.ToString() + "|" );
            }

            Console.WriteLine(Environment.NewLine);
        }

        /*public void Insert()
        {
            var conexion = new Conexion();
            conexion.StringConnection = this.string_conexion;

            var entidad = new Notas();
            entidad.Estudiante = "Pruebas";
            entidad.Materia = "Pruebas";
            entidad.Nota1 = 2.4m;
            entidad.Nota2 = 4.5m;
            entidad.Nota3 = 3.8m;
            entidad.Nota4 = 1.7m;
            entidad.Nota5 = 3.7m;
            entidad.NotaFinal = 0.0m;
            entidad.Fecha = DateTime.Now;

            conexion.Notas!.Add(entidad);
            conexion.SaveChanges();
        }

        public void Update()
        {
            var conexion = new Conexion();
            conexion.StringConnection = this.string_conexion;

            var entidad = conexion.Notas!
                .FirstOrDefault(x => x.Estudiante == "Pruebas");
            if (entidad == null)
                return;

            entidad.NotaFinal =
                (entidad.Nota1 + entidad.Nota2 + entidad.Nota3 + entidad.Nota4 + entidad.Nota5) / 5;

            var entry = conexion.Entry<Notas>(entidad);
            entry.State = EntityState.Modified;
            conexion.SaveChanges();
        }

        public void Delete()
        {
            var conexion = new Conexion();
            conexion.StringConnection = this.string_conexion;

            var entidad = conexion.Notas!
                .FirstOrDefault(x => x.Estudiante == "Pruebas");

            if (entidad == null)
                return;

            conexion.Notas!.Remove(entidad);
            conexion.SaveChanges();
        }*/

    }
}