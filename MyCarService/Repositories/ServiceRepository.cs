using MyCarService.Interfaces;
using MyCarService.Models.DatabaseModels;

namespace MyCarService.Repositories
{
    public class ServiceRepository : GenericRepository<Service>, IServiceRepository
    {
        public ServiceRepository(MyCarServiceContext context) : base(context)
        {
        }
        public IEnumerable<Service> GetVehicleSerivces(int vehicleId) => Find(s => s.VehicleId == vehicleId);

    }
}
