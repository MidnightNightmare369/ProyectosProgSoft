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
            this.IConexion!.Clientes!.Remove(entidad); this.IConexion.SaveChanges(); return entidad;
        }

        public Clientes? Guardar(Clientes? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0) throw new Exception("lbYaSeGuardo");
            //entidad!.Total = (entidad!._Tarifa!.Valor * entidad!.Tiempo ); //calcular total
            this.IConexion!.Clientes!.Add(entidad); this.IConexion.SaveChanges();
            return entidad;
        }

        public Clientes? Modificar(Clientes? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0) throw new Exception("lbNoSeGuardo");
            //entidad!.Total = (entidad!._Tarifa!.Valor * entidad!.Tiempo); //calcular total
            var entry = this.IConexion!.Entry<Clientes>(entidad); entry.State = EntityState.Modified; this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Clientes> Listar()
        {
            return this.IConexion!.Clientes!.Take(20).ToList();
        }

        public List<Clientes> PorCedula(Clientes? entidad)
        {
            return this.IConexion!.Clientes!
                .Where(x => x.Cedula!.Contains(entidad!.Cedula!))
                .ToList();//lo puse string para poder hacer este metodo [preguntar al profe si esta bien]
        }

    }
}
