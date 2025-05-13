using Microsoft.AspNetCore.Mvc;
using EDAula_202502462032.Models;
using EDAula_202502462032.Data;
using System.Linq;

namespace EDAula_202502462032.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Employee
        public IActionResult EmployeeMenu()
        {
            return View();
        }

        // GET: /Employee/Index
        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();
            return View(employees);
        }

        // GET: /Employee/Add
        [HttpGet]
        public IActionResult Add()
        {
            return View(new Employee());
        }

        // POST: /Employee/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction("EmployeeMenu");
            }
            return View(employee);
        }

        // GET: /Employee/Edit/{id}
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: /Employee/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var existingEmployee = _context.Employees.Find(id);
                if (existingEmployee == null)
                {
                    return NotFound();
                }

                // Actualiza los campos del empleado
                existingEmployee.Username = employee.Username;
                existingEmployee.Password = employee.Password;
                existingEmployee.Role = employee.Role;

                _context.Update(existingEmployee);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(employee);
        }
    }
}