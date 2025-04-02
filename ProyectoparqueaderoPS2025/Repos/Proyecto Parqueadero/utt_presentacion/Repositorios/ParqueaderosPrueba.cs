using libr_repositorios.Implementaciones;
using libr_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using utt_presentacion.Nucleo;
using libr_dominio.Entidades;

namespace utt_presentacion.Repositorios
{
    [TestClass]
    public class ParqueaderosPrueba
    {
        private readonly IConexion? iConexion;
        private List<Parqueaderos>? lista;
        private Parqueaderos? entidad;

        public ParqueaderosPrueba()
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
            lista = iConexion!.Parqueaderos!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            entidad = EntidadesNucleo.Parqueaderos()!;
            iConexion!.Parqueaderos!.Add(entidad);
            iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            entidad!.Nombre = "MOD-" + DateTime.Now.ToString("yyyyMMddHHmmss");

            var entry = iConexion!.Entry<Parqueaderos>(entidad);
            entry.State = EntityState.Modified;
            iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            iConexion!.Parqueaderos!.Remove(entidad!);
            iConexion!.SaveChanges();
            return true;
        }
    }
}