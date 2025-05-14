using Microsoft.EntityFrameworkCore;
using EDAula_202502462032.Data;

var builder = WebApplication.CreateBuilder(args);

// Configurar la conexión a la base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 25))));

// Otros servicios
builder.Services.AddControllersWithViews();

// Configurar Entity Framework Core con MySQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))); 

var app = builder.Build();

// Configuración de middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}");
    // pattern: "{controller=Admin}/{action=Dashboard}/{id?}");

app.MapControllerRoute(
    name: "auth",
    pattern: "{controller=Auth}/{action=Login}/{id?}");

app.MapControllerRoute(
    name: "admin",
    pattern: "{controller=Admin}/{action=Dashboard}/{id?}");

app.MapControllerRoute(
    name: "employee",
    pattern: "Employee/{action=EmployeeMenu}/{id?}",
    defaults: new { controller = "Employee" });

app.MapControllerRoute(
    name: "route",
    pattern: "Route/{action=Index}/{id?}",
    defaults: new { controller = "Route" });

app.Run();