using Microsoft.AspNetCore.Mvc;
using MyCarService.Interfaces;
using MyCarService.Models.DatabaseModels;
using System.Net;


namespace MyCarService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OwnerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public OwnerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("add")]
        [HttpPost]
        public ActionResult Create(Owner owner)
        {
            _unitOfWork.OwnerRepository.Add(owner);
            _unitOfWork.Complete();

            return new ObjectResult(HttpStatusCode.Created);
        }

        [Route("update")]
        [HttpPost]
        public ActionResult Update(Owner owner)
        {
            var tmpOwner = _unitOfWork.OwnerRepository.GetById(owner.Id);
            if (tmpOwner == null)
            {
                return new ObjectResult(HttpStatusCode.NotFound);
            }
            tmpOwner.Name = owner.Name;
            tmpOwner.Surname = owner.Surname;
            _unitOfWork.Complete();

            return Ok();
        }

        [Route("get")]
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_unitOfWork.OwnerRepository.GetAll());
        }

        [Route("get/{ownerId}")]
        [HttpGet]
        public ActionResult Get(int ownerId)
        {
            return Ok(_unitOfWork.OwnerRepository.GetById(ownerId));
        }
    }
}
