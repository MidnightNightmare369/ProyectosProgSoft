using lib_dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lib_repositorios.implementaciones
{
    public class ConexionEF
    {
        private string string_conexion = "server=SALAK403-22;database=db_colegio;Integrated Security=True;TrustServerCertificate=true;";
        // server=localhost;database=db_clase12032025;uid=sa;pwd=Clas3sPrO2024_!;TrustServerCertificate=true;
        // server=localhost;database=db_clase12032025;Integrated Security=True;TrustServerCertificate=true;

        public void ConexionBasica()
        {
            var conexion = new Conexion();
            conexion.StringConnection = this.string_conexion;

            var lista = conexion.Notas.ToList();

            foreach (var elemento in lista)
            {
                Console.WriteLine(elemento.Id.ToString() + ", " +
                    elemento.Estudiante + ", " +
                    elemento.Materias + ", " +
                    elemento.Nota1.ToString() + ", " +
                    elemento.Nota2.ToString() + ", " +
                    elemento.Nota3.ToString() + ", " +
                    elemento.Nota4.ToString() + ", " +
                    elemento.Nota5.ToString() + ", " +
                    elemento.NotaFinal.ToString() + ", " +
                    elemento.Fecha.ToString() + ", " 
                    );
            }
        }
    }

    public partial class Conexion : DbContext
    {
        public string? StringConnection { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConnection!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<Notas>? Notas { get; set; }
    }
}
