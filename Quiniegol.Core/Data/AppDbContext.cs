using Microsoft.EntityFrameworkCore;
using Quiniegol.Core.Models;
using System;
using System.IO;

namespace Quiniegol.Core.Data
{
    // Contexto utilizado por Entity Framework Core para trabajar con la base de datos de Quiniegol.
    public class AppDbContext : DbContext
    {
        // Cada DbSet representa una tabla de la base de datos.
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Equipo> Equipos { get; set; }

        public DbSet<Partido> Partidos { get; set; }

        public DbSet<Pronostico> Pronosticos { get; set; }

        // Configura la conexión con SQLite.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Utiliza la base de datos ubicada dentro de Quiniegol.Core.
            string rutaBaseDatos = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "quiniegol.db");

            optionsBuilder.UseSqlite($"Data Source={rutaBaseDatos}");
        }

        // Define las claves primarias de las tablas.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasKey(u => u.IdEmpleado);

            modelBuilder.Entity<Equipo>().HasKey(e => e.IdEquipo);

            modelBuilder.Entity<Partido>().HasKey(p => p.IdPartido);

            modelBuilder.Entity<Pronostico>().HasKey(p => p.IdPronostico);
        }
    }
}