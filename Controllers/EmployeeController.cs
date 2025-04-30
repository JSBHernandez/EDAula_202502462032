using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class EmployeeController : Controller
{
    private readonly ApplicationDbContext _context;

    public EmployeeController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: /Employee
    public IActionResult Index()
    {
        var employees = _context.Employees.ToList();
        return Ok(employees); // Devuelve la lista de empleados
    }

    // POST: /Employee/Create
    [HttpPost]
    public IActionResult Create([FromBody] Employee employee)
    {
        if (ModelState.IsValid)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return Ok(employee);
        }
        return BadRequest(ModelState);
    }

    // PUT: /Employee/Edit/{id}
    [HttpPut("{id}")]
    public IActionResult Edit(int id, [FromBody] Employee employee)
    {
        var existingEmployee = _context.Employees.Find(id);
        if (existingEmployee == null)
        {
            return NotFound();
        }

        existingEmployee.FirstName = employee.FirstName;
        existingEmployee.LastName = employee.LastName;
        existingEmployee.Role = employee.Role;
        existingEmployee.Email = employee.Email;
        existingEmployee.PhoneNumber = employee.PhoneNumber;

        _context.SaveChanges();
        return Ok(existingEmployee);
    }

    // DELETE: /Employee/Delete/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var employee = _context.Employees.Find(id);
        if (employee == null)
        {
            return NotFound();
        }

        _context.Employees.Remove(employee);
        _context.SaveChanges();
        return Ok();
    }
}