namespace EDAula_202502462032.Models
{
    public class Luggage
    {
        public int Id { get; set; } // Identificación del equipaje
        public double Weight { get; set; } // Peso
        public string CargoCarId { get; set; } // Identificación del vagón de carga
        public int TicketId { get; set; } // Relación con el boleto
        public Ticket Ticket { get; set; } // Navegación al boleto
        public int TrainId { get; set; } // Relación con el tren
    }
}