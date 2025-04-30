namespace EDAula_202502462032.Data;
using Microsoft.EntityFrameworkCore;
using Models = EDAula_202502462032.Models; // Crea un alias para tus modelos

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // Registra las entidades en el contexto
    public DbSet<Models.Train> Trains { get; set; }
    public DbSet<Models.Route> Routes { get; set; } 
    public DbSet<Models.Ticket> Tickets { get; set; }
    public DbSet<Models.Passenger> Passengers { get; set; }
    public DbSet<Models.Luggage> Luggages { get; set; }
    public DbSet<Models.Station> Stations { get; set; }
    public DbSet<Models.Employee> Employees { get; set; }
}