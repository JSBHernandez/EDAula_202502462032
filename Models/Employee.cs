namespace EDAula_202502462032.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Username { get; set; } // Nombre de usuario para iniciar sesión
        public string Password { get; set; } // Contraseña para iniciar sesión
        public string Role { get; set; } // "Administrador" o "Empleado"
    }
}