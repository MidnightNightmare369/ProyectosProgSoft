using libr_aplicaciones.Interfaces;
using libr_dominio.Entidades;
using libr_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace libr_aplicaciones.Implementaciones
{
    public class ClientesApp : IClientesApp
    {
        private IConexion? IConexion = null;

        public ClientesApp(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Clientes? Borrar(Clientes? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0) throw new Exception("lbNoSeGuardo");

            var objAuditoria = new Auditorias()
            {
                Clase = "Clientes",
                IdModificado = entidad.Id,
                TipoModificacion = "Eliminación",
                Fecha = DateTime.Now
            };

            this.IConexion!.Auditorias!.Add(objAuditoria);
            this.IConexion!.Clientes!.Remove(entidad); this.IConexion.SaveChanges(); 
            return entidad;
        }

        public Clientes? Guardar(Clientes? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0) throw new Exception("lbYaSeGuardo");

            var objAuditoria = new Auditorias()
            {
                Clase = "Clientes",
                IdModificado = entidad.Id,
                TipoModificacion = "Creación",
                Fecha = DateTime.Now
            };

            this.IConexion!.Auditorias!.Add(objAuditoria);
            this.IConexion!.Clientes!.Add(entidad); this.IConexion.SaveChanges();
            return entidad;
        }

        public Clientes? Modificar(Clientes? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0) throw new Exception("lbNoSeGuardo");

            var objAuditoria = new Auditorias()
            {
                Clase = "Clientes",
                IdModificado = entidad.Id,
                TipoModificacion = "Modificación",
                Fecha = DateTime.Now
            };

            this.IConexion!.Auditorias!.Add(objAuditoria);
            var entry = this.IConexion!.Entry<Clientes>(entidad); entry.State = EntityState.Modified; this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Clientes> Listar()
        {
            return this.IConexion!.Clientes!
                .Take(20)
                .Include(x => x._TipoCliente)
                .Include(x => x._Vehiculo)
                .ToList();
        }

        public List<Clientes> PorCedula(Clientes? entidad)
        {
            return this.IConexion!.Clientes!
                .Where(x => x.Cedula!.Contains(entidad!.Cedula!))
                .Include(x => x._TipoCliente)
                .Include(x => x._Vehiculo)
                .ToList();//lo puse string para poder hacer este metodo [preguntar al profe si esta bien]
        }

    }
}
