using MyCarService.Interfaces;
using MyCarService.Models.DatabaseModels;
using MyCarService.ErrorHandling;


namespace MyCarService.UnitsOfWork
{
    public class VehicleUnitOfWork : UnitOfWork, IVehicleUnitOfWork
    {
        public VehicleUnitOfWork(MyCarServiceContext context) : base(context)
        {
        }

        public IResult<Vehicle, Error> AddNewVehicle(Vehicle vehicle)
        {
            if (ModelRepository.GetById(vehicle.ModelId) == null)
                return new Result<Vehicle, Error>(new Error("Model doesn't exist in database"));
            if (OwnerRepository.GetById(vehicle.OwnerId) == null)
                return new Result<Vehicle, Error>(new Error("Model doesn't exist in database"));
            
            VehicleRepository.Add(vehicle);
            Complete();

            return new Result<Vehicle,Error>(vehicle);
        }
    }
}
