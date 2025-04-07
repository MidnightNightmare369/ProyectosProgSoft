using libr_aplicaciones.Implementaciones;
using libr_aplicaciones.Interfaces;
using libr_dominio.Entidades;
using libr_repositorios.Implementaciones;
using libr_repositorios.Interfaces;
using utt_presentacion.Nucleo;

namespace ut_presentacion.Aplicaciones
{
    [TestClass]
    public class NotasPrueba
    {
        private readonly IParqueaderosClientesApp? iAplicacion;
        private readonly IConexion? iConexion;
        private List<ParqueaderosClientes>? lista;
        private ParqueaderosClientes? entidad;

        public NotasPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            iAplicacion = new ParqueaderosClientesApp(iConexion);
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
            this.lista = this.iAplicacion!.Listar();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.ParqueaderosClientes()!;
            this.iAplicacion!.Guardar(this.entidad);
            return true;
        }

        public bool Modificar()
        {
            this.iAplicacion!.Modificar(this.entidad);
            return true;
        }

        public bool Borrar()
        {
            this.iAplicacion!.Borrar(this.entidad);
            return true;
        }
    }
}