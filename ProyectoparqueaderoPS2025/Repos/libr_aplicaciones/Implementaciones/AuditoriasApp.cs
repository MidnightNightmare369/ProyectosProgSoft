using libr_aplicaciones.Interfaces;
using libr_dominio.Entidades;
using libr_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace libr_aplicaciones.Implementaciones
{
    public class AuditoriasApp : IAuditoriasApp
    {
        private IConexion? IConexion = null;

        public AuditoriasApp(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Auditorias? Borrar(Auditorias? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0) throw new Exception("lbNoSeGuardo");
            this.IConexion!.Auditorias!.Remove(entidad); this.IConexion.SaveChanges(); return entidad;
        }

        public Auditorias? Guardar(Auditorias? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0) throw new Exception("lbYaSeGuardo");
            //entidad!.Total = (entidad!._Tarifa!.Valor * entidad!.Tiempo); //calcular total
            this.IConexion!.Auditorias!.Add(entidad); this.IConexion.SaveChanges();
            return entidad;
        }

        public Auditorias? Modificar(Auditorias? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0) throw new Exception("lbNoSeGuardo");
            //entidad!.Total = (entidad!._Tarifa!.Valor * entidad!.Tiempo); //calcular total
            var entry = this.IConexion!.Entry<Auditorias>(entidad); entry.State = EntityState.Modified; this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Auditorias> Listar()
        {
            return this.IConexion!.Auditorias!.Take(20).ToList();
        }

        public List<Auditorias> PorTipoModificacion(Auditorias? entidad)
        {
            return this.IConexion!.Auditorias!
                .Where(x => x.TipoModificacion!.Contains(entidad!.TipoModificacion!))
                .ToList();//lo puse string para poder hacer este metodo [preguntar al profe si esta bien]
        }

    }
}
