using libr_aplicaciones.Interfaces;
using libr_dominio.Entidades;
using libr_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace libr_aplicaciones.Implementaciones
{
    public class ParqueaderosApp : IParqueaderosApp
    {
        private IConexion? IConexion = null;

        public ParqueaderosApp(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Parqueaderos? Borrar(Parqueaderos? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0) throw new Exception("lbNoSeGuardo");
            this.IConexion!.Parqueaderos!.Remove(entidad); this.IConexion.SaveChanges(); return entidad;
        }

        public Parqueaderos? Guardar(Parqueaderos? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0) throw new Exception("lbYaSeGuardo");
            //entidad!.Total = (entidad!._Tarifa!.Valor * entidad!.Tiempo ); //calcular total
            this.IConexion!.Parqueaderos!.Add(entidad); this.IConexion.SaveChanges();
            return entidad;
        }

        public Parqueaderos? Modificar(Parqueaderos? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0) throw new Exception("lbNoSeGuardo");
            //entidad!.Total = (entidad!._Tarifa!.Valor * entidad!.Tiempo); //calcular total
            var entry = this.IConexion!.Entry<Parqueaderos>(entidad); entry.State = EntityState.Modified; this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Parqueaderos> Listar()
        {
            return this.IConexion!.Parqueaderos!.Take(20).ToList();
        }

        public List<Parqueaderos> PorNombre(Parqueaderos? entidad)
        {
            return this.IConexion!.Parqueaderos!
                .Where(x => x.Nombre!.Contains(entidad!.Nombre!))
                .ToList();//lo puse string para poder hacer este metodo [preguntar al profe si esta bien]
        }

    }
}
