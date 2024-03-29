﻿using MyCarService.Interfaces.Repository;
using MyCarService.Models.DatabaseModels;

namespace MyCarService.Repositories
{
    public class ServiceRepository : GenericRepository<Service>, IServiceRepository
    {
        public ServiceRepository(MyCarServiceContext context) : base(context)
        {
        }
        public IEnumerable<Service> GetVehicleSerivces(long vehicleId) => Find(s => s.VehicleId == vehicleId);

    }
}
