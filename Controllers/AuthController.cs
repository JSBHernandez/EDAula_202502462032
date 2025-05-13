using Microsoft.AspNetCore.Mvc;
using EDAula_202502462032.Models;
using System.Collections.Generic;

namespace EDAula_202502462032.Controllers
{
    public class AuthController : Controller
    {
        private static List<Employee> Employees = new List<Employee>
        {
            new Employee { Id = 1, Username = "admin", Password = "admin", Role = "Administrador" }
        };

        // Página de inicio de sesión
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Manejar el inicio de sesión
        [HttpPost]
        public IActionResult Login(LoginModel login)
        {
            var user = Employees.Find(e => e.Username == login.Username && e.Password == login.Password);
            if (user != null)
            {
                if (user.Role == "Administrador")
                {
                    return RedirectToAction("Dashboard", "Admin");
                }
                return Unauthorized("No tienes permisos para acceder.");
            }
            return Unauthorized("Credenciales incorrectas.");
        }

        // Crear un empleado (solo accesible para administradores)
        [HttpPost]
        public IActionResult CreateEmployee(Employee employee)
        {
            if (employee.Role != "Empleado")
            {
                return BadRequest("Solo se pueden crear usuarios con el rol de 'Empleado'.");
            }

            Employees.Add(employee);
            return Ok("Empleado creado exitosamente.");
        }
    }
}