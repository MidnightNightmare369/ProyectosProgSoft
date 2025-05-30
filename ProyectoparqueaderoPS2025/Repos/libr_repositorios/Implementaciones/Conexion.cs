﻿using libr_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using libr_dominio.Entidades;


namespace libr_repositorios.Implementaciones
{    public partial class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<Parqueaderos>? Parqueaderos { get; set; }
        public DbSet<Tarifas>? Tarifas { get; set; }
        public DbSet<TipoClientes>? TipoClientes { get; set; }
        public DbSet<TipoPagos>? TipoPagos { get; set; }
        public DbSet<TipoVehiculos>? TipoVehiculos { get; set; }
        public DbSet<Vehiculos>? Vehiculos { get; set; }
        public DbSet<Clientes>? Clientes { get; set; }
        public DbSet<Cargos>? Cargos { get; set; }
        public DbSet<Turnos>? Turnos { get; set; }
        public DbSet<Contratos>? Contratos { get; set; }
        public DbSet<Empleados>? Empleados { get; set; }
        public DbSet<Auditorias>? Auditorias { get; set; }
        public DbSet<ParqueaderosClientes>? ParqueaderosClientes { get; set; }

    }
}
