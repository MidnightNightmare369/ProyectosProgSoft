using libr_aplicaciones.Interfaces;
using libr_dominio.Entidades;
using libr_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace libr_aplicaciones.Implementaciones
{
    public class TipoVehiculosApp : ITipoVehiculosApp
    {
        private IConexion? IConexion = null;

        public TipoVehiculosApp(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public TipoVehiculos? Borrar(TipoVehiculos? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0) throw new Exception("lbNoSeGuardo");

            var objAuditoria = new Auditorias()
            {
                Clase = "TipoVehiculos",
                IdModificado = entidad.Id,
                TipoModificacion = "Eliminación",
                Fecha = DateTime.Now
            };

            this.IConexion!.Auditorias!.Add(objAuditoria);
            this.IConexion!.TipoVehiculos!.Remove(entidad); this.IConexion.SaveChanges();
            return entidad;
        }

        public TipoVehiculos? Guardar(TipoVehiculos? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0) throw new Exception("lbYaSeGuardo");

            var objAuditoria = new Auditorias()
            {
                Clase = "TipoVehiculos",
                IdModificado = entidad.Id,
                TipoModificacion = "Creación",
                Fecha = DateTime.Now
            };

            this.IConexion!.Auditorias!.Add(objAuditoria);
            this.IConexion!.TipoVehiculos!.Add(entidad); this.IConexion.SaveChanges();
            return entidad;
        }

        public TipoVehiculos? Modificar(TipoVehiculos? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0) throw new Exception("lbNoSeGuardo");

            var objAuditoria = new Auditorias()
            {
                Clase = "TipoVehiculos",
                IdModificado = entidad.Id,
                TipoModificacion = "Modificación",
                Fecha = DateTime.Now
            };

            this.IConexion!.Auditorias!.Add(objAuditoria);
            var entry = this.IConexion!.Entry<TipoVehiculos>(entidad); entry.State = EntityState.Modified; this.IConexion.SaveChanges();
            return entidad;
        }

        public List<TipoVehiculos> Listar()
        {
            return this.IConexion!.TipoVehiculos!.Take(20).ToList();
        }

        public List<TipoVehiculos> PorTipoVehiculo(TipoVehiculos? entidad)
        {
            return this.IConexion!.TipoVehiculos!
                .Where(x => x.TipoVehiculo!.Contains(entidad!.TipoVehiculo!))
                .ToList();//lo puse string para poder hacer este metodo [preguntar al profe si esta bien]
        }

    }
}
