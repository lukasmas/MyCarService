using MyCarService.Models.DatabaseModels;
using MyCarService.ErrorHandling;
using MyCarService.Interfaces.UnitOfWork;

namespace MyCarService.UnitsOfWork
{
    public class VehicleUnit : UnitOfWork, IVehicleUnit
    {
        public VehicleUnit(MyCarServiceContext context) : base(context)
        {
        }

        public IResult<Vehicle, Error> AddNewVehicle(Vehicle vehicle)
        {
            if (ModelRepository.GetById(vehicle.ModelId) == null)
                return new Result<Vehicle, Error>(new Error(ErrorCode.InvalidData,"Bad modelId"));
            if (OwnerRepository.GetById(vehicle.OwnerId) == null)
                return new Result<Vehicle, Error>(new Error(ErrorCode.InvalidData, "Bad ownerId"));

            VehicleRepository.Add(vehicle);
            Complete();

            return new Result<Vehicle, Error>(vehicle);
        }

        public IResult<Vehicle, Error> UpdateMillage(long vehicleId, uint newMileage)
        {

            var vehicle = VehicleRepository.GetById(vehicleId);
            if (vehicle == null)
            {
                return new Result<Vehicle, Error>(new Error(ErrorCode.InvalidData, "Vehicle dosen't exits"));

            }
            vehicle.CurrentMileage = newMileage;
            Complete();
            return new Result<Vehicle, Error>(vehicle);
        }

        public IResult<Vehicle, Error> DeleteVehicle(long vehicleId)
        {
            var vehicle = VehicleRepository.GetById(vehicleId);
            if (vehicle == null)
            {
                return new Result<Vehicle, Error>(new Error(ErrorCode.InvalidData, "Vehicle dosen't exits"));

            }
            VehicleRepository.Remove(vehicle);
            Complete();
            return new Result<Vehicle, Error>(vehicle);
        }

    }
}
