using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EDAula_202502462032.Models;
using EDAula_202502462032.Data; 
using System.Collections.Generic;
using System.Linq;

namespace EDAula_202502462032.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

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
            // Busca al usuario en la base de datos
            var user = _context.Employees.FirstOrDefault(e => e.Username == login.Username && e.Password == login.Password);

            if (user != null)
            {
                if (user.Role == "Administrador")
                {
                    // Redirige al Dashboard del AdminController
                    return RedirectToAction("Dashboard", "Admin");
                }
                return Unauthorized("No tienes permisos para acceder.");
            }

            // Si las credenciales son incorrectas
            ModelState.AddModelError(string.Empty, "Usuario o contraseña incorrectos.");
            return View();
        }

        // Crear un empleado
        [HttpPost]
        public IActionResult CreateEmployee(Employee employee)
        {
            if (employee.Role != "Empleado")
            {
                return BadRequest("Solo se pueden crear usuarios con el rol de 'Empleado'.");
            }

            _context.Employees.Add(employee);
            _context.SaveChanges();
            return Ok("Empleado creado exitosamente.");
        }
    }
}