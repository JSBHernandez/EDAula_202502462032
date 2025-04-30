namespace EDAula_202502462032.Models;
using System.Collections.Generic;

public class Route
{
    public int Id { get; set; }
    public string Origin { get; set; }
    public string Destination { get; set; }
    public int Distance { get; set; } // Distancia en kilómetros
    public ICollection<Station> Stations { get; set; }
}