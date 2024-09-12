using Microsoft.EntityFrameworkCore;
using ProyectoDos.APIRest.Datos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
builder.Services.AddScoped<IDatosFactura, DatosFactura>();

//conexion a base de datos
builder.Services.AddDbContext<ConexionBDcontext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("ConexionPorDefecto")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
