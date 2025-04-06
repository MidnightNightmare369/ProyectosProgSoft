using libr_repositorios.Implementaciones;
using libr_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using utt_presentacion.Nucleo;
using libr_dominio.Entidades;

namespace utt_presentacion.Repositorios
{
    [TestClass]
    public class ParqueaderosClientesPrueba
    {
        private readonly IConexion? iConexion;
        private List<ParqueaderosClientes>? lista;
        private ParqueaderosClientes? entidad;

        public ParqueaderosClientesPrueba()
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
            lista = iConexion!.ParqueaderosClientes!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            entidad = new ParqueaderosClientes
            {
                Tiempo = 2,
                Posicion = "A1-TEST-" + DateTime.Now.ToString("yyyyMMddHHmmss"),
                Total = 9000,
                Tarifa = 1,
                TipoPago = 1,
                Cliente = 1,
                Parqueadero = 1
            };

            iConexion!.ParqueaderosClientes!.Add(entidad);
            iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            entidad!.Posicion = "MOD-" + DateTime.Now.ToString("yyyyMMddHHmmss");
            entidad.Tiempo = 22;

            var entry = iConexion!.Entry<ParqueaderosClientes>(entidad);
            entry.State = EntityState.Modified;
            iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            iConexion!.ParqueaderosClientes!.Remove(entidad!);
            iConexion!.SaveChanges();
            return true;
        }
    }
}
