using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCarService.ErrorHandling;
using MyCarService.Interfaces;
using MyCarService.Models.DatabaseModels;
using System.Net;
using Service = MyCarService.Models.DatabaseModels.Service;

namespace MyCarService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController : Controller
    {
        private readonly IVehicleUnitOfWork _vehicleUnitOfWork;
        public VehicleController(IVehicleUnitOfWork vehicleUnitOfWork)
        {
            _vehicleUnitOfWork = vehicleUnitOfWork;
        }


        [Route("add")]
        [HttpPost]
        public ActionResult Add(Vehicle vehicle)
        {
            var result = _vehicleUnitOfWork.AddNewVehicle(vehicle);
            if (result.IsFail())
            {
                return BadRequest(result.GetError());
            }
            return Ok(result.GetSuccess());
        }

        [Route("vehicles/{ownerId}")]
        [HttpGet]
        public ActionResult GetAllVehicles(int ownerId)
        {
            return Ok(_vehicleUnitOfWork.VehicleRepository.GetAllOwnerVehicles(ownerId));
        }

        [Route("delete/{vehicleId}")]
        [HttpDelete]
        public ActionResult Delete(int vehicleId)
        {
            var vehicle = _vehicleUnitOfWork.VehicleRepository.GetById(vehicleId);
            if (vehicle == null)
            {
                return new ObjectResult(HttpStatusCode.NotFound);
            }
            _vehicleUnitOfWork.VehicleRepository.Remove(vehicle);
            _vehicleUnitOfWork.Complete();
            return Ok();
        }

        [Route("update/{vehicleId}/{newMillage}")]
        [HttpPut]
        public ActionResult UpdateMillage(int vehicleId, uint newMillage)
        {
            var vehicle = _vehicleUnitOfWork.VehicleRepository.GetById(vehicleId);
            if(vehicle == null)
            {
                return new ObjectResult(HttpStatusCode.NotFound);
            }
            vehicle.CurrentMillage = newMillage;
            _vehicleUnitOfWork.Complete();
            return Ok();
        }

    }
}
