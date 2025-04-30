using System.Collections.Generic;
using System.Linq;

public class RouteService
{
    private readonly ApplicationDbContext _context;

    public RouteService(ApplicationDbContext context)
    {
        _context = context;
    }

    // Método para calcular la ruta más corta usando el algoritmo de Dijkstra
    public List<string> GetShortestRoute(string origin, string destination)
    {
        // Crear un grafo basado en las rutas disponibles
        var graph = BuildGraph();

        // Inicializar las distancias y los nodos visitados
        var distances = new Dictionary<string, int>();
        var previous = new Dictionary<string, string>();
        var nodes = new List<string>();

        foreach (var station in graph.Keys)
        {
            distances[station] = station == origin ? 0 : int.MaxValue;
            nodes.Add(station);
        }

        while (nodes.Count > 0)
        {
            // Ordenar los nodos por distancia
            nodes.Sort((x, y) => distances[x] - distances[y]);
            var smallest = nodes[0];
            nodes.Remove(smallest);

            if (smallest == destination)
            {
                // Construir la ruta más corta
                var path = new List<string>();
                while (previous.ContainsKey(smallest))
                {
                    path.Add(smallest);
                    smallest = previous[smallest];
                }
                path.Add(origin);
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

        return new List<string>(); // No se encontró una ruta
    }

    // Método para construir el grafo basado en las rutas
    private Dictionary<string, Dictionary<string, int>> BuildGraph()
    {
        var graph = new Dictionary<string, Dictionary<string, int>>();

        var routes = _context.Routes.ToList();
        foreach (var route in routes)
        {
            if (!graph.ContainsKey(route.Origin))
            {
                graph[route.Origin] = new Dictionary<string, int>();
            }
            if (!graph.ContainsKey(route.Destination))
            {
                graph[route.Destination] = new Dictionary<string, int>();
            }

            graph[route.Origin][route.Destination] = route.Distance;
            graph[route.Destination][route.Origin] = route.Distance; // Grafo no dirigido
        }

        return graph;
    }
}