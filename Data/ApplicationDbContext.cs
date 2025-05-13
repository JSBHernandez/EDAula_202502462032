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
    }
}