using Microsoft.EntityFrameworkCore;
using EDAula_202502462032.Models;
using RouteModel = EDAula_202502462032.Models.Route; // Alias para evitar conflicto

namespace EDAula_202502462032.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; } // Tabla para empleados
        public DbSet<Train> Trains { get; set; } // Tabla para trenes
        public DbSet<RouteModel> Routes { get; set; } // Tabla para rutas
        public DbSet<Passenger> Passengers { get; set; } // Tabla para pasajeros
        public DbSet<Luggage> Luggages { get; set; } // Tabla para equipajes
        public DbSet<Station> Stations { get; set; } // Tabla para estaciones
        public DbSet<Ticket> Tickets { get; set; } // Tabla para boletos

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Station>().HasData(
                new Station { Id = 1, Name = "A", Location = "Ubicación A" },
                new Station { Id = 2, Name = "B", Location = "Ubicación B" },
                new Station { Id = 3, Name = "C", Location = "Ubicación C" },
                new Station { Id = 4, Name = "D", Location = "Ubicación D" },
                new Station { Id = 5, Name = "E", Location = "Ubicación E" },
                new Station { Id = 6, Name = "F", Location = "Ubicación F" },
                new Station { Id = 7, Name = "G", Location = "Ubicación G" },
                new Station { Id = 8, Name = "H", Location = "Ubicación H" },
                new Station { Id = 9, Name = "I", Location = "Ubicación I" },
                new Station { Id = 10, Name = "J", Location = "Ubicación J" },
                new Station { Id = 11, Name = "K", Location = "Ubicación K" }
            );
        }
    }
}