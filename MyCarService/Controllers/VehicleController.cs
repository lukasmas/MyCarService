using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCarService.ErrorHandling;
using MyCarService.Interfaces.UnitOfWork;
using MyCarService.Models.DatabaseModels;
using System.Net;
using System.Security.Claims;

namespace MyCarService.Controllers
{
    [ApiController]
    [Route("vehicle")]
    public class VehicleController : Controller
    {
        private readonly IVehicleUnit _vehicleUnitOfWork;
        public VehicleController(IVehicleUnit vehicleUnitOfWork)
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

        [Route("vehicles")]
        [HttpGet]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult GetAll()
        {
            var id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)!.Value;
            var ownerId = _vehicleUnitOfWork.UserRepository.Find(u => u.Id == id).First().OwnerId;

            if (ownerId == null)
            {
                return BadRequest();
            }

            return Ok(_vehicleUnitOfWork.VehicleRepository.GetAllOwnerVehicles((long)ownerId!));
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
