using libr_aplicaciones.Interfaces;
using libr_dominio.Entidades;
using libr_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace libr_aplicaciones.Implementaciones
{
    public class ParqueaderosClientesApp : IParqueaderosClientesApp
    {
        private IConexion? IConexion = null;

        public ParqueaderosClientesApp(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public ParqueaderosClientes? Borrar(ParqueaderosClientes? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0) throw new Exception("lbNoSeGuardo");
            this.IConexion!.ParqueaderosClientes!.Remove(entidad); this.IConexion.SaveChanges(); return entidad;
        }

        public ParqueaderosClientes? Guardar(ParqueaderosClientes? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0) throw new Exception("lbYaSeGuardo");
            entidad!.Total = (entidad!._Tarifa!.Valor * entidad!.Tiempo ); //calcular total
            this.IConexion!.ParqueaderosClientes!.Add(entidad); this.IConexion.SaveChanges(); 
            return entidad;
        }

        public ParqueaderosClientes? Modificar(ParqueaderosClientes? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0) throw new Exception("lbNoSeGuardo");
            entidad!.Total = (entidad!._Tarifa!.Valor * entidad!.Tiempo); //calcular total
            var entry = this.IConexion!.Entry<ParqueaderosClientes>(entidad); entry.State = EntityState.Modified; this.IConexion.SaveChanges(); 
            return entidad;
        }

        public List<ParqueaderosClientes> Listar()
        {
            return this.IConexion!.ParqueaderosClientes!.Take(20).ToList();
        }

        public List<ParqueaderosClientes> PorPosicion(ParqueaderosClientes? entidad)
        {
            return this.IConexion!.ParqueaderosClientes!
                .Where(x => x.Posicion!.Contains(entidad!.Posicion!)) 
                .ToList();//lo puse string para poder hacer este metodo [preguntar al profe si esta bien]
        }

    }
}
