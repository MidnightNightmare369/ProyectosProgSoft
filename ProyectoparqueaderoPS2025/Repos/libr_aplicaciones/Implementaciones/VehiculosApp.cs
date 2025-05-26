using libr_aplicaciones.Interfaces;
using libr_dominio.Entidades;
using libr_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace libr_aplicaciones.Implementaciones
{
    public class VehiculosApp : IVehiculosApp
    {
        private IConexion? IConexion = null;

        public VehiculosApp(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Vehiculos? Borrar(Vehiculos? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0) throw new Exception("lbNoSeGuardo");

            var objAuditoria = new Auditorias()
            {
                Clase = "Vehiculos",
                IdModificado = entidad.Id,
                TipoModificacion = "Eliminación",
                Fecha = DateTime.Now
            };

            this.IConexion!.Auditorias!.Add(objAuditoria);
            this.IConexion!.Vehiculos!.Remove(entidad); this.IConexion.SaveChanges();
            return entidad;
        }

        public Vehiculos? Guardar(Vehiculos? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0) throw new Exception("lbYaSeGuardo");

            var objAuditoria = new Auditorias()
            {
                Clase = "Vehiculos",
                IdModificado = entidad.Id,
                TipoModificacion = "Creación",
                Fecha = DateTime.Now
            };

            this.IConexion!.Auditorias!.Add(objAuditoria);
            this.IConexion!.Vehiculos!.Add(entidad); this.IConexion.SaveChanges();
            return entidad;
        }

        public Vehiculos? Modificar(Vehiculos? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0) throw new Exception("lbNoSeGuardo");

            var objAuditoria = new Auditorias()
            {
                Clase = "Vehiculos",
                IdModificado = entidad.Id,
                TipoModificacion = "Modificación",
                Fecha = DateTime.Now
            };

            this.IConexion!.Auditorias!.Add(objAuditoria);
            var entry = this.IConexion!.Entry<Vehiculos>(entidad); entry.State = EntityState.Modified; this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Vehiculos> Listar()
        {
            return this.IConexion!.Vehiculos!
                .Take(20)
                .Include(x => x._TipoVehiculo)
                .ToList();
        }

        public List<Vehiculos> PorPlaca(Vehiculos? entidad)
        {
            return this.IConexion!.Vehiculos!
                .Where(x => x.Placa!.Contains(entidad!.Placa!))
                .Include(x => x._TipoVehiculo)
                .ToList();//lo puse string para poder hacer este metodo [preguntar al profe si esta bien]
        }

    }
}
