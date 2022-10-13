using MyCarService.Models.DatabaseModels;

namespace MyCarService.Interfaces
{
    public interface IVehicleRepository : IGenericRepository<Vehicle>
    {
        IEnumerable<Vehicle> GetAllOwnerVehicles(int ownerId);
    }
}
