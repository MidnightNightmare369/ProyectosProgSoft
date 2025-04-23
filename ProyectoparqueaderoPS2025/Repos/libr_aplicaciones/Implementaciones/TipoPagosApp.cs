using libr_aplicaciones.Interfaces;
using libr_dominio.Entidades;
using libr_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace libr_aplicaciones.Implementaciones
{
    public class TipoPagosApp : ITipoPagosApp
    {
        private IConexion? IConexion = null;

        public TipoPagosApp(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public TipoPagos? Borrar(TipoPagos? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0) throw new Exception("lbNoSeGuardo");
            this.IConexion!.TipoPagos!.Remove(entidad); this.IConexion.SaveChanges(); return entidad;
        }

        public TipoPagos? Guardar(TipoPagos? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0) throw new Exception("lbYaSeGuardo");
            //entidad!.Total = (entidad!._Tarifa!.Valor * entidad!.Tiempo ); //calcular total
            this.IConexion!.TipoPagos!.Add(entidad); this.IConexion.SaveChanges();
            return entidad;
        }

        public TipoPagos? Modificar(TipoPagos? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0) throw new Exception("lbNoSeGuardo");
            //entidad!.Total = (entidad!._Tarifa!.Valor * entidad!.Tiempo); //calcular total
            var entry = this.IConexion!.Entry<TipoPagos>(entidad); entry.State = EntityState.Modified; this.IConexion.SaveChanges();
            return entidad;
        }

        public List<TipoPagos> Listar()
        {
            return this.IConexion!.TipoPagos!.Take(20).ToList();
        }

        public List<TipoPagos> PorTipoPago(TipoPagos? entidad)
        {
            return this.IConexion!.TipoPagos!
                .Where(x => x.TipoPago!.Contains(entidad!.TipoPago!))
                .ToList();//lo puse string para poder hacer este metodo [preguntar al profe si esta bien]
        }

    }
}