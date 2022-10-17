using Microsoft.EntityFrameworkCore;
using MyCarService.Models.DatabaseModels;

public class MyCarServiceContext : DbContext
{
    public MyCarServiceContext(DbContextOptions<MyCarServiceContext> options)
               : base(options)
    {
    }
    public MyCarServiceContext() { }

    public virtual DbSet<Vehicle>? Vehicle { get; set; } = null;
    public virtual DbSet<Make>? CarMake { get; set; } = null;
    public virtual DbSet<Model>? CarModel { get; set; } = null;
    public virtual DbSet<Owner>? Owner { get; set; } = null;
    public virtual DbSet<Service>? Service { get; set; } = null;
    public virtual DbSet<User>? User { get; set; } = null;



}