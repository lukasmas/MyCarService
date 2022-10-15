using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyCarService.AuthService;
using MyCarService.Interfaces;
using MyCarService.Repositories;
using MyCarService.UnitsOfWork;
using System.Text;

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
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IVehicleUnitOfWork, VehicleUnitOfWork>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("JWTSecretKey")))
        };
    });

builder.Services.AddSingleton<IAuthService>(
               new AuthService(
                   builder.Configuration.GetValue<string>("JWTSecretKey"),
                   builder.Configuration.GetValue<int>("JWTLifespan")
               )
           );

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
