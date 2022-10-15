using MyCarService.Models.DatabaseModels;

namespace MyCarService.Interfaces
{
    public interface IServiceRepository : IGenericRepository<Service>
    {
        IEnumerable<Service> GetVehicleSerivces(long vehicleId);

    }
}
