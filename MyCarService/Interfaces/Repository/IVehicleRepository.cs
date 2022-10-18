using MyCarService.Models.DatabaseModels;

namespace MyCarService.Interfaces.Repository
{
    public interface IVehicleRepository : IGenericRepository<Vehicle>
    {
        IEnumerable<Vehicle> GetAllOwnerVehicles(long ownerId);
    }
}
