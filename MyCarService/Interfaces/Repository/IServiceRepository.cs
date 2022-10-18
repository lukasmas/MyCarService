using MyCarService.Models.DatabaseModels;

namespace MyCarService.Interfaces.Repository
{
    public interface IServiceRepository : IGenericRepository<Service>
    {
        IEnumerable<Service> GetVehicleSerivces(long vehicleId);

    }
}
