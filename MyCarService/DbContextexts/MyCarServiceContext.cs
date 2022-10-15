using Microsoft.EntityFrameworkCore;
using MyCarService.Models.DatabaseModels;

public class MyCarServiceContext : DbContext
{
    public MyCarServiceContext(DbContextOptions<MyCarServiceContext> options)
               : base(options)
    {
    }

    public DbSet<Vehicle> Vehicle { get; set; }
    public DbSet<Make> CarMake { get; set; }
    public DbSet<Model> CarModel { get; set; }
    public DbSet<Owner> Owner { get; set; }
    public DbSet<Service> Service { get; set; }
    public DbSet<User> User { get; set; }



}