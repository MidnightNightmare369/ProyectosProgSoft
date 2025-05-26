using libr_aplicaciones.Interfaces;
using libr_dominio.Entidades;
using libr_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace libr_aplicaciones.Implementaciones
{
    public class EmpleadosApp : IEmpleadosApp
    {
        private IConexion? IConexion = null;

        public EmpleadosApp(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Empleados? Borrar(Empleados? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0) throw new Exception("lbNoSeGuardo");

            var objAuditoria = new Auditorias()
            {
                Clase = "Empleados",
                IdModificado = entidad.Id,
                TipoModificacion = "Eliminación",
                Fecha = DateTime.Now
            };

            this.IConexion!.Auditorias!.Add(objAuditoria);
            this.IConexion!.Empleados!.Remove(entidad); this.IConexion.SaveChanges();
            return entidad;
        }

        public Empleados? Guardar(Empleados? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0) throw new Exception("lbYaSeGuardo");

            var objAuditoria = new Auditorias()
            {
                Clase = "Empleados",
                IdModificado = entidad.Id,
                TipoModificacion = "Creación",
                Fecha = DateTime.Now
            };

            this.IConexion!.Auditorias!.Add(objAuditoria);
            this.IConexion!.Empleados!.Add(entidad); this.IConexion.SaveChanges();
            return entidad;
        }

        public Empleados? Modificar(Empleados? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0) throw new Exception("lbNoSeGuardo");

            var objAuditoria = new Auditorias()
            {
                Clase = "Empleados",
                IdModificado = entidad.Id,
                TipoModificacion = "Modificación",
                Fecha = DateTime.Now
            };

            this.IConexion!.Auditorias!.Add(objAuditoria);
            var entry = this.IConexion!.Entry<Empleados>(entidad); entry.State = EntityState.Modified; this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Empleados> Listar()
        {
            return this.IConexion!.Empleados!
                .Take(20)
                .Include(x => x._Cargo)
                .Include(x => x._Turno)
                .Include(x => x._Contrato)
                .ToList();
        }

        public List<Empleados> PorCedula(Empleados? entidad)
        {
            return this.IConexion!.Empleados!
                .Where(x => x.Cedula!.Contains(entidad!.Cedula!))
                .Include(x => x._Cargo)
                .Include(x => x._Turno)
                .Include(x => x._Contrato)
                .ToList();//lo puse string para poder hacer este metodo [preguntar al profe si esta bien]
        }

    }
}