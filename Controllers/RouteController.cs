using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Models = EDAula_202502462032.Models; // Alias para los modelos
using EDAula_202502462032.Data;


public class RouteController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly RouteService _routeService;

    public RouteController(ApplicationDbContext context)
    {
        _context = context;
        _routeService = new RouteService(context);
    }

    // GET: /Route
    public IActionResult Index()
    {
        var routes = _context.Routes.ToList();
        return Ok(routes); // Devuelve la lista de rutas
    }

    // POST: /Route/Create
    [HttpPost]
    public IActionResult Create([FromBody] Models.Route route) // Usa el alias para evitar conflictos
    {
        if (ModelState.IsValid)
        {
            _context.Routes.Add(route);
            _context.SaveChanges();
            return Ok(route);
        }
        return BadRequest(ModelState);
    }

    // PUT: /Route/Edit/{id}
    [HttpPut("{id}")]
    public IActionResult Edit(int id, [FromBody] Models.Route route) // Usa el alias aquí también
    {
        var existingRoute = _context.Routes.Find(id);
        if (existingRoute == null)
        {
            return NotFound();
        }

        existingRoute.Origin = route.Origin;
        existingRoute.Destination = route.Destination;
        existingRoute.Distance = route.Distance;

        _context.SaveChanges();
        return Ok(existingRoute);
    }

    // DELETE: /Route/Delete/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var route = _context.Routes.Find(id);
        if (route == null)
        {
            return NotFound();
        }

        _context.Routes.Remove(route);
        _context.SaveChanges();
        return Ok();
    }

    // GET: /Route/ShortestRoute
    [HttpGet("ShortestRoute")]
    public IActionResult ShortestRoute(string origin, string destination)
    {
        var shortestRoute = _routeService.GetShortestRoute(origin, destination);
        if (shortestRoute.Count == 0)
        {
            return NotFound("No se encontró una ruta entre las estaciones especificadas.");
        }
        return Ok(shortestRoute);
    }
}