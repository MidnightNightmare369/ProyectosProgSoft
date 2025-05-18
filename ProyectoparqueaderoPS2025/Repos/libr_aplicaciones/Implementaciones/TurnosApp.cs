using libr_aplicaciones.Interfaces;
using libr_dominio.Entidades;
using libr_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace libr_aplicaciones.Implementaciones
{
    public class TurnosApp : ITurnosApp
    {
        private IConexion? IConexion = null;

        public TurnosApp(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Turnos? Borrar(Turnos? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0) throw new Exception("lbNoSeGuardo");
            this.IConexion!.Turnos!.Remove(entidad); this.IConexion.SaveChanges(); return entidad;
        }

        public Turnos? Guardar(Turnos? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0) throw new Exception("lbYaSeGuardo");
            //entidad!.Total = (entidad!._Tarifa!.Valor * entidad!.Tiempo); //calcular total
            this.IConexion!.Turnos!.Add(entidad); this.IConexion.SaveChanges();
            return entidad;
        }

        public Turnos? Modificar(Turnos? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0) throw new Exception("lbNoSeGuardo");
            //entidad!.Total = (entidad!._Tarifa!.Valor * entidad!.Tiempo); //calcular total
            var entry = this.IConexion!.Entry<Turnos>(entidad); entry.State = EntityState.Modified; this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Turnos> Listar()
        {
            return this.IConexion!.Turnos!.Take(20).ToList();
        }

        public List<Turnos> PorTurno(Turnos? entidad)
        {
            return this.IConexion!.Turnos!
                .Where(x => x.Turno!.Contains(entidad!.Turno!))
                .ToList();//lo puse string para poder hacer este metodo [preguntar al profe si esta bien]
        }

    }
}
