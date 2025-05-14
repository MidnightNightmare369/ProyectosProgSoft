using libr_repositorios.Implementaciones;
using libr_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using utt_presentacion.Nucleo;
using libr_dominio.Entidades;

namespace utt_presentacion.Repositorios
{
    [TestClass]
    public class ContratosPrueba
    {
        private readonly IConexion? iConexion;
        private List<Contratos>? lista;
        private Contratos? entidad;

        public ContratosPrueba()
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
            lista = iConexion!.Contratos!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            entidad = EntidadesNucleo.Contratos()!;
            iConexion!.Contratos!.Add(entidad);
            iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            entidad!.FechaInicio = "MOD-" + DateTime.Now.ToString("yyyyMMddHHmmss");

            var entry = iConexion!.Entry<Contratos>(entidad);
            entry.State = EntityState.Modified;
            iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            iConexion!.Contratos!.Remove(entidad!);
            iConexion!.SaveChanges();
            return true;
        }
    }
}