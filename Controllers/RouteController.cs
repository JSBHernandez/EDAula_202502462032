using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EDAula_202502462032.Models;
using EDAula_202502462032.Data;
using System.Linq;
using System.Collections.Generic;

namespace EDAula_202502462032.Controllers
{
    public class RouteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RouteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Route
        [HttpGet]
        public IActionResult Index()
        {
            var routes = _context.Routes.ToList();
            return View(routes);
        }

        // GET: /Route/Add
        [HttpGet]
        public IActionResult Add()
        {
            // Poblar la lista de estaciones desde la base de datos
            ViewBag.Stations = _context.Stations.Select(s => new SelectListItem
            {
                Value = s.Name, // El valor que se enviará al servidor
                Text = s.Name   // El texto que se mostrará en el menú desplegable
            }).ToList();

            // Poblar la lista de trenes desde la base de datos
            ViewBag.Trains = _context.Trains.Select(t => new SelectListItem
            {
                Value = t.Name,
                Text = t.Name
            }).ToList();

            return View(new EDAula_202502462032.Models.Route());
        }

        // POST: /Route/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(EDAula_202502462032.Models.Route route)
        {
            if (ModelState.IsValid)
            {
                // Guardar la nueva ruta en la base de datos
                _context.Routes.Add(route);
                _context.SaveChanges();

                // Redirigir al menú de rutas (Index)
                return RedirectToAction("Index");
            }

            // Si hay errores, recargar las listas desplegables
            ViewBag.Trains = _context.Trains.Select(t => new SelectListItem
            {
                Value = t.Name,
                Text = t.Name
            }).ToList();

            ViewBag.Stations = _context.Stations.Select(s => new SelectListItem
            {
                Value = s.Name,
                Text = s.Name
            }).ToList();

            return View(route);
        }

        // GET: /Route/Edit/{id}
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var route = _context.Routes.Find(id);
            if (route == null)
            {
                return NotFound();
            }
            return View(route);
        }

        // POST: /Route/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EDAula_202502462032.Models.Route route)
        {
            if (id != route.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var existingRoute = _context.Routes.Find(id);
                if (existingRoute == null)
                {
                    return NotFound();
                }

                existingRoute.Train = route.Train;
                existingRoute.Origin = route.Origin;
                existingRoute.Destination = route.Destination;
                existingRoute.IntermediateStations = route.IntermediateStations;
                existingRoute.Distance = route.Distance;

                _context.Update(existingRoute);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.Stations = _context.Stations.Select(s => new SelectListItem
            {
                Value = s.Name,
                Text = s.Name
            }).ToList();

            return View(route);
        }

        // GET: /Route/ShortestPath
        public IActionResult ShortestPath(string origin, string destination)
        {
            // Implementación del algoritmo de Dijkstra
            var graph = GetGraph();
            var shortestPath = Dijkstra(graph, origin, destination);

            ViewBag.Origin = origin;
            ViewBag.Destination = destination;
            ViewBag.ShortestPath = shortestPath;

            return View();
        }

        private Dictionary<string, Dictionary<string, int>> GetGraph()
        {
            return new Dictionary<string, Dictionary<string, int>>
            {
                { "A", new Dictionary<string, int> { { "B", 30 }, { "C", 40 }, { "D", 50 }, { "F", 50 } } },
                { "B", new Dictionary<string, int> { { "A", 30 } } },
                { "C", new Dictionary<string, int> { { "A", 40 }, { "I", 80 }, { "J", 120 }, { "K", 110 } } },
                { "D", new Dictionary<string, int> { { "A", 50 }, { "E", 20 } } },
                { "E", new Dictionary<string, int> { { "D", 20 }, { "F", 65 } } },
                { "F", new Dictionary<string, int> { { "A", 50 }, { "E", 65 }, { "G", 80 } } },
                { "G", new Dictionary<string, int> { { "F", 80 }, { "H", 30 }, { "I", 145 } } },
                { "H", new Dictionary<string, int> { { "G", 30 } } },
                { "I", new Dictionary<string, int> { { "C", 80 }, { "G", 145 } } },
                { "J", new Dictionary<string, int> { { "C", 120 } } },
                { "K", new Dictionary<string, int> { { "C", 110 } } }
            };
        }

        private List<string> Dijkstra(Dictionary<string, Dictionary<string, int>> graph, string start, string end)
        {
            var distances = new Dictionary<string, int>();
            var previous = new Dictionary<string, string>();
            var nodes = new List<string>();

            foreach (var vertex in graph)
            {
                if (vertex.Key == start)
                {
                    distances[vertex.Key] = 0;
                }
                else
                {
                    distances[vertex.Key] = int.MaxValue;
                }

                nodes.Add(vertex.Key);
            }

            while (nodes.Count != 0)
            {
                nodes.Sort((x, y) => distances[x] - distances[y]);
                var smallest = nodes[0];
                nodes.Remove(smallest);

                if (smallest == end)
                {
                    var path = new List<string>();
                    while (previous.ContainsKey(smallest))
                    {
                        path.Add(smallest);
                        smallest = previous[smallest];
                    }

                    path.Add(start);
                    path.Reverse();
                    return path;
                }

                if (distances[smallest] == int.MaxValue)
                {
                    break;
                }

                foreach (var neighbor in graph[smallest])
                {
                    var alt = distances[smallest] + neighbor.Value;
                    if (alt < distances[neighbor.Key])
                    {
                        distances[neighbor.Key] = alt;
                        previous[neighbor.Key] = smallest;
                    }
                }
            }

            return new List<string>();
        }
    }
}