using System.Collections.Generic;
namespace EDAula_202502462032.Models;

public class Route
{
    public int Id { get; set; }
    public string Origin { get; set; }
    public string Destination { get; set; }
    public string Schedule { get; set; } // Horario de la ruta
    public bool IsPublished { get; set; } = false; // Estado de publicación
    public bool HasStarted { get; set; } = false; // Indica si la ruta ya inició
    public int Distance { get; set; } // km
    public ICollection<Station> Stations { get; set; }
}