using System.ComponentModel.DataAnnotations;

namespace EDAula_202502462032.Models
{
    public class TicketDemoViewModel
    {
        public string TrainId { get; set; } // Tren seleccionado

        [Display(Name = "Fecha y hora de salida")]
        public string DepartureDateTime { get; set; } // Fecha y hora de salida

        [Display(Name = "Fecha y hora de llegada")]
        public string ArrivalDateTime { get; set; } // Fecha y hora de llegada

        [Display(Name = "Precio del boleto")]
        public decimal TicketPrice { get; set; } // Precio del boleto

        // Datos del pasajero
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "El número de teléfono es obligatorio.")]
        [Phone(ErrorMessage = "El número de teléfono no es válido.")]
        public string PhoneNumber { get; set; }

        // Contacto de emergencia
        [Required(ErrorMessage = "El nombre del contacto de emergencia es obligatorio.")]
        public string EmergencyContactName { get; set; }

        [Required(ErrorMessage = "El teléfono del contacto de emergencia es obligatorio.")]
        [Phone(ErrorMessage = "El número de teléfono no es válido.")]
        public string EmergencyContactPhone { get; set; }
    }
}