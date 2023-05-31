using ControleFluxoCaixa.API;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;


var builder = WebApplication.CreateBuilder(args);

var loggerConfiguration = new LoggerConfiguration()
    .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Debug)
    .WriteTo.File("log.txt", restrictedToMinimumLevel: LogEventLevel.Information)
    .MinimumLevel.Verbose();

Log.Logger = loggerConfiguration.CreateLogger();

builder.Logging.AddSerilog();

// Add services to the container.
builder.Services.ConfigureRepositories();
builder.Services.ConfigureMediatR();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ControleFluxoCaixa.API", Version = "v1" });
   
});

var app = builder.Build();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ControleFluxoCaixa.API v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
