using TFGHotel.Context;
using Microsoft.EntityFrameworkCore;
// mis servicios
using TFGHotel.Services.Reservas;
using TFGHotel.Services.Usuarios;
using TFGHotel.Services.Clientes;
using TFGHotel.Services.ReservasDeServicios;
using TFGHotel.Services.Habitaciones;
using TFGHotel.Services.HabitacionesDisponibles;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// ---------------------------------------------------------------------------------
// ! Importante:    aqui indico con qué servicios van a trabajar los controladores de mi WEB API
builder.Services.AddScoped<IUsuariosService, UsuariosService>();
builder.Services.AddScoped<IClientesService, ClientesService>();
builder.Services.AddScoped<IReservasDeHabitacionesService, ReservasDeHabitacionesService>();
builder.Services.AddScoped<IReservasDeServicios, ReservasDeServicios>();
builder.Services.AddScoped<ITiposDeHabitacionesService, TiposDeHabitacionesService>();
builder.Services.AddScoped<IHabitacionesDisponiblesService, HabitacionesDisponiblesService>();
// ---------------------------------------------------------------------------------

// Añado el contexto (objeto base de datos con todas sus tablas)
builder.Services.AddDbContext<FCT10Context>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("defaultConnection"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Añado estas 2 líneas para permitir peticiones desde cualquier origen, cualquier método y cualquier header
app.UseRouting();
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


app.UseAuthorization();

app.MapControllers();

app.Run();
