using Microsoft.AspNetCore.Mvc;
using System.Linq;
using EDAula_202502462032.Models;
using EDAula_202502462032.Data;

namespace EDAula_202502462032.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Dashboard(Employee employee)
        {
            if (employee.Role == "Administrador")
            {
                return View("AdminDashboard"); // Vista para administradores
            }
            else if (employee.Role == "Empleado")
            {
                return View("EmployeeDashboard"); // Vista para empleados normales
            }
            else
            {
                return Unauthorized(); // Acceso no autorizado
            }
        }
    }
}