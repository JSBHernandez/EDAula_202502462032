using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EDAula_202502462032.Models;
using EDAula_202502462032.Data;
using System.Linq;

namespace EDAula_202502462032.Controllers
{
    public class TrainController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrainController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Menú principal de administración de trenes
        public IActionResult TrainMenu()
        {
            return View();
        }

        // GET: /Train/Add
        [HttpGet]
        public IActionResult Add()
        {
            return View(new Train()); // Pasa un modelo vacío a la vista
        }

        // POST: /Train/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Train train)
        {
            if (ModelState.IsValid)
            {
                // Validar la capacidad máxima de vagones según el tipo de tren
                if (train.PassengerCapacity > train.MaxWagons)
                {
                    ModelState.AddModelError("PassengerCapacity", $"La capacidad máxima para el tipo {train.Type} es de {train.MaxWagons} vagones.");
                    return View(train);
                }

                _context.Trains.Add(train); // Agrega el tren a la base de datos
                _context.SaveChanges(); // Guarda los cambios
                return RedirectToAction("TrainMenu"); // Redirige al menú de gestión de trenes
            }
            return View(train); // Si el modelo no es válido, vuelve a mostrar la vista con los errores
        }

        // GET: /Train/Index
        public IActionResult Index()
        {
            var trains = _context.Trains.ToList(); // Obtiene todos los trenes de la base de datos
            return View(trains); // Pasa la lista de trenes a la vista
        }

        // GET: /Train/Delete/{id}
        public IActionResult Delete(int id)
        {
            var train = _context.Trains.Find(id);
            if (train == null)
            {
                return NotFound();
            }
            return View(train);
        }

        // POST: /Train/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var train = _context.Trains.Find(id);
            if (train != null)
            {
                _context.Trains.Remove(train); // Elimina el tren de la base de datos
                _context.SaveChanges(); // Guarda los cambios
                return RedirectToAction("TrainMenu"); // Redirige al menú de gestión de trenes
            }
            return NotFound("El tren especificado no existe.");
        }

        // GET: /Train/Edit/{id}
        public IActionResult Edit(int id)
        {
            var train = _context.Trains.Find(id);
            if (train == null)
            {
                return NotFound();
            }
            return View(train);
        }

        // POST: /Train/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Train train)
        {
            if (id != train.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Validar la capacidad máxima de vagones según el tipo de tren
                if (train.PassengerCapacity > train.MaxWagons)
                {
                    ModelState.AddModelError("PassengerCapacity", $"La capacidad máxima para el tipo {train.Type} es de {train.MaxWagons} vagones.");
                    return View(train);
                }

                _context.Update(train); // Actualiza el tren en la base de datos
                _context.SaveChanges(); // Guarda los cambios
                return RedirectToAction("Index"); // Redirige al listado de trenes
            }
            return View(train); // Si el modelo no es válido, vuelve a mostrar la vista con los errores
        }
    }
}