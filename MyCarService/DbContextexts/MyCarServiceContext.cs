using Microsoft.EntityFrameworkCore;
using MyCarService.Models.Dto;

public class MyCarServiceContext : DbContext
{
    public MyCarServiceContext(DbContextOptions<MyCarServiceContext> options)
               : base(options)
    {
    }

    //public DbSet<VehicleDto> Vehicle { get; set; }
    public DbSet<MakeDto>? CarMake { get; set; }
    public DbSet<ModelDto>? CarModel { get; set; }
    public DbSet<OwnerDto>? Owner { get; set; }

}