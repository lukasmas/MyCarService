using MyCarService.Interfaces;
using MyCarService.Models.DatabaseModels;

namespace MyCarService.Repositories
{
    public class VehicleRepository : GenericRepository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(MyCarServiceContext context) : base(context)
        {
        }

        public IEnumerable<Vehicle> GetAllOwnerVehicles(int ownerId) => Find(v => v.OwnerId == ownerId);

    }
}
