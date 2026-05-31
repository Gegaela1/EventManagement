using EventManagement.DataAccess.Context;
using EventManagement.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// CONTROLLERS (API)
builder.Services.AddControllers();

// SWAGGER / OPEN API

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader());
});


// DATABASE (DbContext)
// Configura la conexión a SQL Server
builder.Services.AddDbContext<EventDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// REPOSITORIES (acceso a datos)

// Generic repository
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// Repository específico de Event
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IAttendeeRepository, AttendeeRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();

// SERVICES (lógica de negocio)
builder.Services.AddScoped<EventService>();
builder.Services.AddScoped<AttendeeService>();
builder.Services.AddScoped<TicketService>();

// AUTOMAPPER (Mapeo DTO <-> Entity)
builder.Services.AddAutoMapper(typeof(Program));



var app = builder.Build();

app.UseCors("AllowAll");

// DATA SEEDER
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<EventDbContext>();
    context.Database.EnsureCreated();
    DataSeeder.Seed(context);
}


// SWAGGER / MIDDLEWARE
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => Results.Redirect("/swagger"));

// CONFIGURACIÓN HTTP
app.UseHttpsRedirection();

// Autorización (no obligatorio aún)
app.UseAuthorization();

// Mapear controllers
app.MapControllers();

// Ejecutar app
app.Run();

