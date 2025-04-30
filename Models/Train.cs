using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace EDAula_202502462032.Models;
public class Train
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Identifier { get; set; }

    [Required]
    public string Type { get; set; } // Mercedes-Benz o Arnold

    [Range(1, 32, ErrorMessage = "La capacidad debe estar entre 1 y 32 vagones.")]
    public int PassengerCapacity { get; set; } // Total de pasajeros

    public int LuggageCapacity { get; set; } // Total de maletas permitidas
    public double Mileage { get; set; }
    public ICollection<Route> Routes { get; set; }
}