using libr_repositorios.Implementaciones;
using libr_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using utt_presentacion.Nucleo;
using libr_dominio.Entidades;

namespace utt_presentacion.Repositorios
{
    [TestClass]
    public class CargosPrueba
    {
        private readonly IConexion? iConexion;
        private List<Cargos>? lista;
        private Cargos? entidad;

        public CargosPrueba()
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
            lista = iConexion!.Cargos!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            entidad = EntidadesNucleo.Cargos()!;
            iConexion!.Cargos!.Add(entidad);
            iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            entidad!.Cargo = "MOD-" + DateTime.Now.ToString("yyyyMMddHHmmss");

            var entry = iConexion!.Entry<Cargos>(entidad);
            entry.State = EntityState.Modified;
            iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            iConexion!.Cargos!.Remove(entidad!);
            iConexion!.SaveChanges();
            return true;
        }
    }
}
