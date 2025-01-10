using InfoDengueAPP.INFRASTRUCTURE.DbContexts;
using InfoDengueAPP.INFRASTRUCTURE.Repositories.Interfaces;
using InfoDengueAPP.INFRASTRUCTURE.Repositories;
using InfoDengueAPP.SERVICES.Interfaces;
using InfoDengueAPP.SERVICES;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ISolicitanteRepository, SolicitanteRepository>();
builder.Services.AddScoped<IRelatorioRepository, RelatorioRepository>();
builder.Services.AddScoped<ISolicitanteService, SolicitanteService>();
builder.Services.AddScoped<IRelatorioService, RelatorioService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "InfoDengueAPP API v1");
        c.RoutePrefix = string.Empty; // Faz o Swagger ser a página inicial
    });
}


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
