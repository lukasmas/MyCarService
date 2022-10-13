using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCarService.Interfaces;
using MyCarService.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MyCarService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController : Controller
    {
        //private readonly MyServiceCarContext _context;

        //public VehicleController(MyServiceCarContext context)
        //{
        //    _context = context;
        //}

        private readonly IUnitOfWork _unitOfWork;
        public VehicleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetVehicleDetalisAsync()
        //{
        //    int id = 1;
        //    //Service service = new Service { ServicType = "Service", Description = "Oil change", VehicleId = 1, ServiceCost = 900 };
        //    //Vehicle vehicle = new Vehicle
        //    //{
        //    //    Make = "Skoda",
        //    //    Model = "Superb 2",
        //    //    RegisteryNumber = "SCI 5555",
        //    //    VIN = "ASSSASA",
        //    //    YearOfProduction = 2013,
        //    //    Services = new List<Service>{service},
        //    //};


        //    //return Ok(vehicle);

        //    //if (id == null)
        //    //{
        //    //    return NotFound();
        //    //}

        //    //var vehicle = await _context.GetVehiclesByIdAsync(id);

        //    return Ok();

        //}

        [Route("CarModels")]
        [HttpGet]
        public ActionResult GetCarModels()
        {

            return Ok(_unitOfWork.ModelRepository.GetAllCars());

        }

    }
}
