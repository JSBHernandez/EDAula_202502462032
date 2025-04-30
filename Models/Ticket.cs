using System;
namespace EDAula_202502462032.Models;
public class Ticket
{
    public int Id { get; set; }
    public DateTime PurchaseDate { get; set; }
    public DateTime DepartureDate { get; set; }
    public DateTime ArrivalDate { get; set; }
    public string SeatCategory { get; set; } // Premium, Executive, Standard
    public double Price { get; set; }
    public int PassengerId { get; set; }
    public Passenger Passenger { get; set; }
    public int TrainId { get; set; }
    public Train Train { get; set; }
}