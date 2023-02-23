using BusBooking.DTO;
using BusBooking.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BusDbContext>(
    opt =>
    {
        opt.UseSqlServer(builder.Configuration.GetConnectionString("mysql"));
    });
builder.Services.AddTransient<IBusInfoRepos,BusInfoRepo>();
builder.Services.AddTransient<IBusRouteRepo, BusRouteRepo>();
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
