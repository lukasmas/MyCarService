using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCarService.Interfaces;
using MyCarService.Models.DatabaseModels;
using System.Net;
using System.Security.Claims;

namespace MyCarService.Controllers
{
    [ApiController]
    [Route("owner")]
    public class OwnerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public OwnerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("add")]
        [HttpPost]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]

        public ActionResult Create(Owner owner)
        {
            var user_id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)!.Value;
            var user = _unitOfWork.UserRepository.Find(u => u.Id == user_id).First();
            if(user.OwnerId == null)
            {
                _unitOfWork.OwnerRepository.Add(owner);
                _unitOfWork.Complete();
                user.OwnerId = owner.Id;
                _unitOfWork.Complete();
                return new ObjectResult(HttpStatusCode.Created);
            }

            return new ObjectResult(new { owner = "Owner already exist for a user" }) { StatusCode =(int) HttpStatusCode.BadRequest };

        }

        [Route("update")]
        [HttpPut]
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

        [Route("delete/{ownerId}")]
        [HttpDelete]
        public ActionResult Delete(long ownerId)
        {
            var owner = _unitOfWork.OwnerRepository.GetById(ownerId);
            if (owner == null)
            {
                return new ObjectResult(HttpStatusCode.NotFound);
            }
            _unitOfWork.OwnerRepository.Remove(owner);
            _unitOfWork.Complete();
            return Ok();

        }

        [Route("get")]
        [HttpGet]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult Get()
        {
            var id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)!.Value;
            
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
