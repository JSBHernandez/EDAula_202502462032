using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EDAula_202502462032.Models
{
    public class Train
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del tren es obligatorio.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El identificador del tren es obligatorio.")]
        public string Identifier { get; set; }

        [Required(ErrorMessage = "El tipo de tren es obligatorio.")]
        public string Type { get; set; } // Mercedes-Benz o Arnold

        [Range(1, 32, ErrorMessage = "La capacidad de carga debe estar entre 1 y 32 vagones.")]
        public int PassengerCapacity { get; set; } // Total de pasajeros

        [Range(0, int.MaxValue, ErrorMessage = "La capacidad de equipaje debe ser un valor positivo.")]
        public int LuggageCapacity { get; set; } // Total de maletas permitidas

        [Range(0, double.MaxValue, ErrorMessage = "El kilometraje debe ser un valor positivo.")]
        public double Mileage { get; set; } // Kilometraje del tren

        // Propiedad calculada para determinar la cantidad máxima de vagones permitidos
        public int MaxWagons
        {
            get
            {
                return Type == "Mercedes-Benz" ? 28 : 32;
            }
        }

        // Método para calcular la cantidad de vagones de carga necesarios
        public int CalculateCargoWagons(int passengerWagons)
        {
            return passengerWagons / 2; // 1 vagón de carga por cada 2 vagones de pasajeros
        }
    }
}