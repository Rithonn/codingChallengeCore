using Microsoft.EntityFrameworkCore;
using BreweryAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<BreweryDBContext>(ServiceLifetime.Transient);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
