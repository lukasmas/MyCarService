using MyCarService.Interfaces;
using MyCarService.Models.DatabaseModels;
using MyCarService.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly MyCarServiceContext _context;
    public UnitOfWork(MyCarServiceContext context)
    {
        _context = context;
        ModelRepository = new ModelRepository(_context);
        MakeRepository = new MakeRepository(_context);
        OwnerRepository = new OwnerRepository(_context);
        VehicleRepository = new VehicleRepository(_context);
        ServiceRepository = new ServiceRepository(_context);
        UserRepository = new UserRepository(_context);

    }
    public IModelRepository ModelRepository { get; private set; }
    public IMakeRepository MakeRepository { get; private set; }
    public IOwnerRepository OwnerRepository { get; private set; }
    public IVehicleRepository VehicleRepository { get; private set; }
    public IServiceRepository ServiceRepository { get; private set; }
    public IUserRepository UserRepository { get; private set; }



    public int Complete()
    {
        return _context.SaveChanges();
    }
    public void Dispose()
    {
        _context.Dispose();
    }

    public Owner GetOwnerById(long ownerId)
    {
        return OwnerRepository.GetById(ownerId);
    }
}
