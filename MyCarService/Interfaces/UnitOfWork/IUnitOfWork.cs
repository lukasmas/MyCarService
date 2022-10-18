using MyCarService.Interfaces.Repository;
using MyCarService.Models.DatabaseModels;

namespace MyCarService.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IModelRepository ModelRepository { get; }
        IMakeRepository MakeRepository { get; }
        IOwnerRepository OwnerRepository { get; }
        IVehicleRepository VehicleRepository { get; }
        IServiceRepository ServiceRepository { get; }
        IUserRepository UserRepository { get; }
        int Complete();
        public Owner GetOwnerById(long ownerId);

    }
}
