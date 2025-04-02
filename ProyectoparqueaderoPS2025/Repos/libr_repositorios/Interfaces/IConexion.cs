using libr_dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace libr_repositorios.Interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }

        DbSet<Parqueaderos>? Parqueaderos { get; set; }
        DbSet<Tarifas>? Tarifas { get; set; }
        DbSet<TipoClientes>? TipoClientes { get; set; }
        DbSet<TipoPagos>? TipoPagos { get; set; }
        DbSet<TipoVehiculos>? TipoVehiculos { get; set; }
        DbSet<Vehiculos>? Vehiculos { get; set; }
        DbSet<ParqueaderosClientes>? ParqueaderosClientes { get; set; }
        DbSet<Clientes>? Clientes { get; set; }

        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}
