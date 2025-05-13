using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EDAula_202502462032.Models
{
    public class Train
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Identifier { get; set; }

        [Required]
        public string Type { get; set; } // Mercedes-Benz o Arnold

        [Range(1, 32, ErrorMessage = "La capacidad de carga debe estar entre 1 y 32 vagones.")]
        public int PassengerCapacity { get; set; } // Total de pasajeros

        public int LuggageCapacity { get; set; } // Total de maletas permitidas

        public double Mileage { get; set; } // Kilometraje del tren

        public ICollection<Route> Routes { get; set; }

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