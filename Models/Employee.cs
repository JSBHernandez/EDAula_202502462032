namespace EDAula_202502462032.Models;
public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Role { get; set; } // Ejemplo: "Administrador", "Operador"
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}