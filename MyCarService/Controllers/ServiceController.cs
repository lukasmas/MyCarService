using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MyCarService.Interfaces.UnitOfWork;
using MyCarService.Models.DatabaseModels;
using System.Net;

namespace MyCarService.Controllers
{
    [ApiController]
    [Route("service")]
    public class ServiceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ServiceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("add")]
        [HttpPost]
        public ActionResult Add(Service service)
        {
            _unitOfWork.ServiceRepository.Add(service);
            _unitOfWork.Complete();
            return new ObjectResult(HttpStatusCode.Created);
        }

        [Route("get/{vehicleId}")]
        [HttpGet]
        public ActionResult Get(int vehicleId)
        {
            return Ok(_unitOfWork.ServiceRepository.GetVehicleSerivces(vehicleId));
        }

    }
}
