namespace MyCarService.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IModelRepository ModelRepository { get; }
        int Complete();
    }
}
