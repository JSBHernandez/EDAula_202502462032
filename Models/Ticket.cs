using System;

namespace EDAula_202502462032.Models
{
    public class Ticket
    {
        public int Id { get; set; } // Id de registro
        public DateTime PurchaseDateTime { get; set; } // Fecha y hora de compra
        public DateTime DepartureDateTime { get; set; } // Fecha y hora de salida
        public DateTime ArrivalDateTime { get; set; } // Fecha y hora de llegada
        public string PassengerId { get; set; } // Identificación del pasajero
        public string FirstName { get; set; } // Nombres
        public string LastName { get; set; } // Apellidos
        public string IdentificationType { get; set; } // Tipo de identificación
        public string Address { get; set; } // Dirección actual
        public string PhoneNumber { get; set; } // Números de teléfono
        public int TrainId { get; set; } // Id del tren
        public string Seat { get; set; } // Lugar
        public string PassengerCategory { get; set; } // Categoría del pasajero (Premium, Ejecutivo, Estándar)
        public decimal TicketPrice { get; set; } // Valor del pasaje
        public string EmergencyContactFirstName { get; set; } // Persona de contacto - nombres
        public string EmergencyContactLastName { get; set; } // Persona de contacto - apellidos
        public string EmergencyContactPhoneNumber { get; set; } // Persona de contacto - números de teléfono
        public ICollection<Luggage> Luggages { get; set; } // Información del equipaje
    }
}