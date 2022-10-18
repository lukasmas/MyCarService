using Microsoft.AspNetCore.Mvc;
using MyCarService.AuthServices;
using MyCarService.Interfaces.Auth;
using MyCarService.Interfaces.UnitOfWork;
using MyCarService.Models.Auth;
using MyCarService.Models.DatabaseModels;
using MyCarService.Repositories;

namespace MyCarService.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : Controller
    {
        readonly IAuthUnit _authUnit;
        public AuthController( IAuthUnit authUnit)
        {
            _authUnit = authUnit;
        }

        [HttpPost("register")]
        public ActionResult<AuthData> Register(UserAuth user)
        {
            var result = _authUnit.RegisterUser(user);

            if (result.IsFail())
            {
                return BadRequest(new { error = result.GetError() });
            }
            return Ok(result.GetSuccess());
        }

        [HttpPost("login")]
        public ActionResult<AuthData> Login(UserAuth user)
        {
            var result = _authUnit.LoginUser(user);

            if (result.IsFail())
            {
                return BadRequest(new { error = result.GetError() });
            }
            return Ok(result.GetSuccess());
        }
    }
}
