using SaludAppBackend.API.ContenedorDepenConfig;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureServiceCollection(builder.Configuration, builder.Environment);

//Configura Serilog como el proveedor de logs global del host de la app
builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Agregando Servicio del CORS para la app Web
//El navegador le da permisos a la app de consumir las apis
builder.Services.AddCors(options =>
{
    options.AddPolicy("_myAllowSpecificOrigins",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("_myAllowSpecificOrigins"); //Agregando cors

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
