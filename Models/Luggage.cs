namespace EDAula_202502462032.Models;
public class Luggage
{
    public int Id { get; set; }
    public double Weight { get; set; } // Peso en kilogramos
    public int PassengerId { get; set; }
    public Passenger Passenger { get; set; }
    public int TrainId { get; set; }
    public Train Train { get; set; }
}