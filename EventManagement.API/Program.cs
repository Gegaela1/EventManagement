using EventManagement.DataAccess.Context;
using EventManagement.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// =====================================
// CONTROLLERS (API)
builder.Services.AddControllers();

// =====================================
// SWAGGER / OPEN API
// =====================================
builder.Services.AddOpenApi();


// =====================================
// DATABASE (DbContext)
// =====================================
// Configura la conexión a SQL Server
builder.Services.AddDbContext<EventDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));


// =====================================
// REPOSITORIES (acceso a datos)
// =====================================
// Generic repository
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// Repository específico de Event
builder.Services.AddScoped<IEventRepository, EventRepository>();


// =====================================
// SERVICES (lógica de negocio)
// =====================================
builder.Services.AddScoped<EventService>();


// =====================================
// AUTOMAPPER (Mapeo DTO <-> Entity)
// =====================================
builder.Services.AddAutoMapper(typeof(Program));



var app = builder.Build();


// =====================================
// SWAGGER / MIDDLEWARE
// =====================================
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


// =====================================
// CONFIGURACIÓN HTTP
// =====================================
app.UseHttpsRedirection();

// Autorización (no obligatorio aún)
app.UseAuthorization();

// Mapear controllers
app.MapControllers();

// Ejecutar app
app.Run();
