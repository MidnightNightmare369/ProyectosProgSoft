using libr_dominio.Entidades;
using libr_repositorios.Implementaciones;
using libr_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using utt_presentacion.Nucleo;

namespace utt_presentacion.Repositorios
{
    [TestClass]
    public class TipoVehiculosPrueba
    {
        private readonly IConexion? iConexion;
        private List<TipoVehiculos>? lista;
        private TipoVehiculos? entidad;

        public TipoVehiculosPrueba()
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
            lista = iConexion!.TipoVehiculos!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            entidad = EntidadesNucleo.TipoVehiculos()!;
            iConexion!.TipoVehiculos!.Add(entidad);
            iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            entidad!.TipoVehiculo = "MOD-" + DateTime.Now.ToString("yyyyMMddHHmmss");

            var entry = iConexion!.Entry<TipoVehiculos>(entidad);
            entry.State = EntityState.Modified;
            iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            iConexion!.TipoVehiculos!.Remove(entidad!);
            iConexion!.SaveChanges();
            return true;
        }
    }
}