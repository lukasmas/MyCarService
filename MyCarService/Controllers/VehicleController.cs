using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCarService.ErrorHandling;
using MyCarService.Interfaces;
using MyCarService.Models.DatabaseModels;
using System.Net;

namespace MyCarService.Controllers
{
    [ApiController]
    [Route("vehicle")]
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
            if (result.IsFail()) return BadRequest(result.GetError());
            return Ok(result.GetSuccess());
        }

        [Route("vehicles/{ownerId}")]
        [HttpGet]
        public ActionResult GetAll(long ownerId)
        {
            return Ok(_vehicleUnitOfWork.VehicleRepository.GetAllOwnerVehicles(ownerId));
        }

        [Route("delete/{vehicleId}")]
        [HttpDelete]
        public ActionResult Delete(long vehicleId)
        {
            var result = _vehicleUnitOfWork.DeleteVehicle(vehicleId);
            if (result.IsFail()) return BadRequest(result.GetError());
            return Ok();
        }

        [Route("update/{vehicleId}/{newMillage}")]
        [HttpPut]
        public ActionResult UpdateMillage(long vehicleId, uint newMillage)
        {
            var result = _vehicleUnitOfWork.UpdateMillage(vehicleId, newMillage);
            if (result.IsFail()) return BadRequest(result.GetError());
            return Ok(result.GetSuccess());
        }

    }
}
