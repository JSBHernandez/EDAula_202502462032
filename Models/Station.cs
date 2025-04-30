namespace EDAula_202502462032.Models;

public class Station
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public ICollection<Route> Routes { get; set; } // Relación con rutas
}