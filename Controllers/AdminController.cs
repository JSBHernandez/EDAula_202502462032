using Microsoft.AspNetCore.Mvc;
using EDAula_202502462032.Models;
using System.Collections.Generic;
using RouteModel = EDAula_202502462032.Models.Route; // Alias para evitar conflicto

namespace EDAula_202502462032.Controllers
{
    public class AdminController : Controller
    {
        private static List<Train> Trains = new List<Train>(); // Lista temporal para almacenar trenes
        private static List<RouteModel> Routes = new List<RouteModel>(); // Usar alias para evitar conflicto

        // Agregar un tren
        [HttpPost]
        public IActionResult AddTrain(Train train)
        {
            if (ModelState.IsValid)
            {
                Trains.Add(train);
                return Ok("Tren agregado exitosamente.");
            }
            return BadRequest("Datos inválidos para el tren.");
        }

        // Dar de baja un tren
        [HttpPost]
        public IActionResult RemoveTrain(int trainId)
        {
            var train = Trains.Find(t => t.Id == trainId);
            if (train != null)
            {
                Trains.Remove(train);
                return Ok("Tren eliminado exitosamente.");
            }
            return NotFound("Tren no encontrado.");
        }

        // Crear una ruta
        [HttpPost]
        public IActionResult CreateRoute(RouteModel route) // Usar alias aquí también
        {
            if (ModelState.IsValid)
            {
                Routes.Add(route);
                return Ok("Ruta creada exitosamente.");
            }
            return BadRequest("Datos inválidos para la ruta.");
        }

        // Publicar una ruta
        [HttpPost]
        public IActionResult PublishRoute(int routeId)
        {
            var route = Routes.Find(r => r.Id == routeId);
            if (route != null)
            {
                route.IsPublished = true;
                return Ok("Ruta publicada exitosamente.");
            }
            return NotFound("Ruta no encontrada.");
        }

        // Modificar horarios y recorridos (si no se han iniciado)
        [HttpPost]
        public IActionResult ModifySchedule(int routeId, string newSchedule)
        {
            var route = Routes.Find(r => r.Id == routeId);
            if (route != null && !route.HasStarted)
            {
                route.Schedule = newSchedule;
                return Ok("Horario modificado exitosamente.");
            }
            return BadRequest("No se puede modificar el horario de una ruta ya iniciada.");
        }

        // Gestionar empleados
        [HttpPost]
        public IActionResult ManageEmployee(Employee employee)
        {
            // Aquí puedes implementar lógica para agregar, editar o eliminar empleados
            return Ok("Empleado gestionado exitosamente.");
        }

        public IActionResult Dashboard()
        {
            return View();
        }
    }
}