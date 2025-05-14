using libr_repositorios.Implementaciones;
using libr_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using utt_presentacion.Nucleo;
using libr_dominio.Entidades;

namespace utt_presentacion.Repositorios
{
    [TestClass]
    public class TurnosPrueba
    {
        private readonly IConexion? iConexion;
        private List<Turnos>? lista;
        private Turnos? entidad;

        public TurnosPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
        }

        [TestMethod]
        public void Ejecutar()
        {
            Assert.AreEqual(true, Guardar());
            Assert.AreEqual(true, Modificar());
            Assert.AreEqual(true, Listar());
            Assert.AreEqual(true, Borrar());
        }

        public bool Listar()
        {
            lista = iConexion!.Turnos!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            entidad = EntidadesNucleo.Turnos()!;
            iConexion!.Turnos!.Add(entidad);
            iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            entidad!.Turno = "MOD-" + DateTime.Now.ToString("yyyyMMddHHmmss");

            var entry = iConexion!.Entry<Turnos>(entidad);
            entry.State = EntityState.Modified;
            iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            iConexion!.Turnos!.Remove(entidad!);
            iConexion!.SaveChanges();
            return true;
        }
    }
}