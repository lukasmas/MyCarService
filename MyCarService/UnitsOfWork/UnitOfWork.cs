using MyCarService.Interfaces;
using MyCarService.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly MyCarServiceContext _context;
    public UnitOfWork(MyCarServiceContext context)
    {
        _context = context;
        ModelRepository = new ModelRepository(_context);
    }
    public IModelRepository ModelRepository { get; private set; }
    public int Complete()
    {
        return _context.SaveChanges();
    }
    public void Dispose()
    {
        _context.Dispose();
    }
}
