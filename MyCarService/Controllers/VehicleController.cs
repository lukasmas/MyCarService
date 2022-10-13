using Microsoft.AspNetCore.Mvc;
using MyCarService.Interfaces;
using MyCarService.Models.DatabaseModels;
using Service = MyCarService.Models.DatabaseModels.Service;

namespace MyCarService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public VehicleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [Route("CarModels")]
        [HttpGet]
        public ActionResult GetCarModels()
        {
            return Ok(_unitOfWork.ModelRepository.GetAllCars());
        }

        [Route("NewOwner")]
        [HttpPost]
        public ActionResult AddNewOwner(Owner owner)
        {
            _unitOfWork.OwnerRepository.Add(owner);
            _unitOfWork.Complete();
            return Ok();
        }

        [Route("Owners")]
        [HttpGet]
        public ActionResult GetAllOwners()
        {
            return Ok(_unitOfWork.OwnerRepository.GetAll());
        }

        [Route("Vehicles/{ownerId}")]
        [HttpGet]
        public ActionResult GetAllVehicles(int ownerId)
        {
            return Ok(_unitOfWork.VehicleRepository.GetAllOwnerVehicles(ownerId));
        }

        [Route("Services/{vehicleId}")]
        [HttpGet]
        public IEnumerable<Service> GetVehicleServices(int vehicleId)
        {
            return _unitOfWork.ServiceRepository.GetVehicleSerivces(vehicleId);
        }





    }
}
