using Microsoft.EntityFrameworkCore;
using AirlinesApp.Models;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<AirlineContext>(opt =>
//opt.UseSqlServer(builder.Configuration.GetConnectionString("AirlineContext") ?? throw new InvalidOperationException("Connection string 'AirlineContext' not found.")));
var connStrName = "AirlineContext";
var str = builder.Configuration.GetConnectionString(connStrName);
Console.WriteLine("connection string '" + connStrName + "': " + str);

//Console.WriteLine("section " + builder.Configuration.GetSection("ConnectionStrings"));

var connectString = @"Server=.\mssqlserver01;Database=airline;Trusted_Connection=True;MultipleActiveResultSets=true";
Console.WriteLine("conn " + connectString);
builder.Services.AddDbContext<AirlineContext>(opt =>
    opt.UseSqlServer(str ?? throw new InvalidOperationException("Connection string 'AirlineContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
