using MyCarService.Models.DatabaseModels;
using MyCarService.ErrorHandling;


namespace MyCarService.Interfaces
{
    public interface IVehicleUnitOfWork : IUnitOfWork
    {
        public IResult<Vehicle, Error> AddNewVehicle(Vehicle vehicle);

        public IResult<Vehicle, Error> UpdateMillage(long vehicleId, uint newMillage);
        public IResult<Vehicle, Error> DeleteVehicle(long vehicleId);


    }
}
