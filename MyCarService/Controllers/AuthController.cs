using Microsoft.AspNetCore.Mvc;
using MyCarService.AuthService;
using MyCarService.Interfaces;
using MyCarService.Models;
using MyCarService.Models.DatabaseModels;
using MyCarService.Repositories;

namespace MyCarService.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : Controller
    {
        readonly IAuthService _authService;
        readonly IUnitOfWork _unitOfWork;
        public AuthController(IAuthService authService, IUnitOfWork unitOfWork)
        {
            _authService = authService;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("register")]
        public ActionResult<AuthData> Register(UserTemplate user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (user.Email == null) return BadRequest(new { email = "emial is not provided" });
            var emailUniq = _unitOfWork.UserRepository.IsEmailUniq(user.Email);
            if (!emailUniq) return BadRequest(new { email = "user with this email already exists" });
            if (user.Username == null) return BadRequest(new { email = "username is not provided" });
            var usernameUniq = _unitOfWork.UserRepository.IsUsernameUniq(user.Username);
            if (!usernameUniq) return BadRequest(new { username = "user with this username already exists" });
            if (user.Password == null) return BadRequest(new { email = "Password is not provided" });

            //var id = Guid.NewGuid().ToString();
            var newUser = new User
            {
                Id = 0,
                Username = user.Username,
                Email = user.Email,
                Salt = AuthSaltGenerator.GetUniqueKey(32),
                Password = ""
            };
            string password = user.Username + user.Password + newUser.Salt;
            newUser.Password = _authService.HashPassword(password);
            _unitOfWork.UserRepository.Add(newUser);
            try
            {
                _unitOfWork.Complete();
            }
            catch
            {
                _unitOfWork.Dispose();
                return BadRequest(new { registery = "Registery has failed" });
            }

            return _authService.GetAuthData(newUser.Id.ToString());
        }

        [HttpPost("login")]
        public ActionResult<AuthData> Post(UserTemplate user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userByEmail = _unitOfWork.UserRepository.Find(u => u.Email == user.Email).FirstOrDefault();

            if (userByEmail == null)
            {
                return BadRequest(new { email = "no user with this email" });
            }
            if (userByEmail.Password == null || user.Password == null) return BadRequest(new { password = "password is empty" });
            string password = user.Username + user.Password + userByEmail.Salt;

            var passwordValid = _authService.VerifyPassword(password, userByEmail.Password);
            if (!passwordValid)
            {
                return BadRequest(new { password = "invalid password" });
            }

            return _authService.GetAuthData(userByEmail.Id.ToString());
        }
    }
}
