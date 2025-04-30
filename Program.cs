using Microsoft.EntityFrameworkCore;
using YourNamespace.Data; // Asegúrate de usar el namespace correcto para tu contexto

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor
builder.Services.AddControllersWithViews();

// Configurar Entity Framework Core con una base de datos en memoria (puedes cambiar esto más adelante)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("EDAula")); // Cambiar a SQL Server más adelante si es necesario

var app = builder.Build();

// Configurar el middleware
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();