using Microsoft.EntityFrameworkCore;
using PizzaNet.Application.Services;
using PizzaNet.Domain.Interface;
using PizzaNet.Infrastructure.Data;
using PizzaNet.Infrastructure.Repository;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddDbContext<PizzaDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ContactsApiConnectionString")));

builder.Services.AddScoped<IPizzaTypeServices, PizzaTypeServices>();
builder.Services.AddScoped<IPizzaTypeRepository, PizzaTypeRepository>();

builder.Services.AddScoped<IPizzaServices, PizzaServices>();
builder.Services.AddScoped<IPizzaRepository, PizzaRepository>();

builder.Services.AddScoped<IOrderServices, OrderServices>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
