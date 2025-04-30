using System.Collections.Generic;
namespace EDAula_202502462032.Models;

public class Route
{
    public int Id { get; set; }
    public string Origin { get; set; }
    public string Destination { get; set; }
    public int Distance { get; set; } // km
    public ICollection<Station> Stations { get; set; }
}