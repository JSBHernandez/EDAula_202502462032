using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EDAula_202502462032.Models
{
    public class Route
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El tren es obligatorio.")]
        public string Train { get; set; } // Nombre del tren asignado a la ruta

        [Required(ErrorMessage = "La estación de origen es obligatoria.")]
        public string Origin { get; set; } // Estación de origen

        [Required(ErrorMessage = "La estación de destino es obligatoria.")]
        public string Destination { get; set; } // Estación de destino

        public List<string> IntermediateStations { get; set; } // Estaciones intermedias

        [Range(0, double.MaxValue, ErrorMessage = "La distancia debe ser un valor positivo.")]
        public double Distance { get; set; } // Distancia total en kilómetros

        // Propiedades adicionales
        public bool IsPublished { get; set; } // Indica si la ruta está publicada
        public bool HasStarted { get; set; } // Indica si la ruta ya ha comenzado
        public DateTime? Schedule { get; set; } // Fecha y hora programada para la ruta
    }
}