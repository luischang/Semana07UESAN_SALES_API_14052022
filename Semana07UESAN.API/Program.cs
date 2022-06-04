using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Semana07UESAN.DOMAIN.Core.Interfaces;
using Semana07UESAN.DOMAIN.Infrastructure.Data;
using Semana07UESAN.DOMAIN.Infrastructure.Mapping;
using Semana07UESAN.DOMAIN.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

//Get Connection String 
var connectionString = builder.Configuration.GetConnectionString("DevConnection");
//Add dbcontext
builder.Services.AddDbContext<SalesContext>(options => options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();

var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutomapperProfile());


});

var mapper = config.CreateMapper();

builder.Services.AddSingleton(mapper);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
