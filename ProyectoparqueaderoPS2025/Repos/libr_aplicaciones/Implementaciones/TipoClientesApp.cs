using libr_aplicaciones.Interfaces;
using libr_dominio.Entidades;
using libr_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace libr_aplicaciones.Implementaciones
{
    public class TipoClientesApp : ITipoClientesApp
    {
        private IConexion? IConexion = null;

        public TipoClientesApp(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public TipoClientes? Borrar(TipoClientes? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0) throw new Exception("lbNoSeGuardo");
            this.IConexion!.TipoClientes!.Remove(entidad); this.IConexion.SaveChanges(); return entidad;
        }

        public TipoClientes? Guardar(TipoClientes? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0) throw new Exception("lbYaSeGuardo");
            //entidad!.Total = (entidad!._Tarifa!.Valor * entidad!.Tiempo ); //calcular total
            this.IConexion!.TipoClientes!.Add(entidad); this.IConexion.SaveChanges();
            return entidad;
        }

        public TipoClientes? Modificar(TipoClientes? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0) throw new Exception("lbNoSeGuardo");
            //entidad!.Total = (entidad!._Tarifa!.Valor * entidad!.Tiempo); //calcular total
            var entry = this.IConexion!.Entry<TipoClientes>(entidad); entry.State = EntityState.Modified; this.IConexion.SaveChanges();
            return entidad;
        }

        public List<TipoClientes> Listar()
        {
            return this.IConexion!.TipoClientes!.Take(20).ToList();
        }

        public List<TipoClientes> PorTipoCliente(TipoClientes? entidad)
        {
            return this.IConexion!.TipoClientes!
                .Where(x => x.TipoCliente!.Contains(entidad!.TipoCliente!))
                .ToList();//lo puse string para poder hacer este metodo [preguntar al profe si esta bien]
        }

    }
}