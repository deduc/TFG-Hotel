using TFGHotel.Context;
using Microsoft.EntityFrameworkCore;

// servicios que va a utilizar mi API (creados por ti para procesar datos)


var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// ---------------------------------------------------------------------------------
// ! Importante:    aqui voy a indicar con qué tablas de la BDD va a trabajar mi API

// ---------------------------------------------------------------------------------

// Añado el contexto (objeto base de datos)
/*
    builder.Services.AddDbContext<Context/ContextClass>(options =>
    {
        options.UseSqlServer(configuration.GetConnectionString("defaultConnection"));
    });
*/


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// añadidos para permitir peticiones desde fuera
app.UseRouting();
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


app.UseAuthorization();

app.MapControllers();

app.Run();
