using libr_aplicaciones.Interfaces;
using libr_dominio.Entidades;
using libr_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace libr_aplicaciones.Implementaciones
{
    public class ContratosApp : IContratosApp
    {
        private IConexion? IConexion = null;

        public ContratosApp(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Contratos? Borrar(Contratos? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0) throw new Exception("lbNoSeGuardo");
            this.IConexion!.Contratos!.Remove(entidad); this.IConexion.SaveChanges(); return entidad;
        }

        public Contratos? Guardar(Contratos? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0) throw new Exception("lbYaSeGuardo");
            //entidad!.Total = (entidad!._Tarifa!.Valor * entidad!.Tiempo); //calcular total
            this.IConexion!.Contratos!.Add(entidad); this.IConexion.SaveChanges();
            return entidad;
        }

        public Contratos? Modificar(Contratos? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0) throw new Exception("lbNoSeGuardo");
            //entidad!.Total = (entidad!._Tarifa!.Valor * entidad!.Tiempo); //calcular total
            var entry = this.IConexion!.Entry<Contratos>(entidad); entry.State = EntityState.Modified; this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Contratos> Listar()
        {
            return this.IConexion!.Contratos!.Take(20).ToList();
        }

        public List<Contratos> PorReferencia(Contratos? entidad)
        {
            return this.IConexion!.Contratos!
                .Where(x => x.Referencia!.Contains(entidad!.Referencia!))
                .ToList();//lo puse string para poder hacer este metodo [preguntar al profe si esta bien]
        }

    }
}
