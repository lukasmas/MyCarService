using Microsoft.EntityFrameworkCore;
using MyCarService.Interfaces;
using MyCarService.Models;
using MyCarService.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyCarServiceContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("MyCarServiceConntext")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<IModelRepository, ModelRepository>();
builder.Services.AddTransient<IMakeRepository, MakeRepository>();
builder.Services.AddTransient<IVehicleRepository, VehicleRepository>();
builder.Services.AddTransient<IServiceRepository, ServiceRepository>();
builder.Services.AddTransient<IOwnerRepository, OwnerRepository>();




builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
//services.AddTransient<IProjectRepository, ProjectRepository>();

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
