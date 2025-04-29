using System.Collections.Generic;

public class Train
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Identifier { get; set; }
    public int Capacity { get; set; }
    public double Mileage { get; set; }
    public ICollection<Route> Routes { get; set; }
}