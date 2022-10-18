using MyCarService.AuthServices;
using MyCarService.ErrorHandling;
using MyCarService.Interfaces.Auth;
using MyCarService.Interfaces.UnitOfWork;
using MyCarService.Models.Auth;
using MyCarService.Models.DatabaseModels;

namespace MyCarService.UnitsOfWork
{
    public class AuthUnit : UnitOfWork, IAuthUnit
    {
        IAuthService _authService;
        public AuthUnit(MyCarServiceContext context, IAuthService authService) : base(context)
        {
            _authService = authService;
        }
        public Result<AuthData, Error> RegisterUser(UserAuth userAuth)
        {
            if (!ChechIfDataNotNull(userAuth))
            {
                return new Result<AuthData, Error>(new Error("Some fields are missing"));
            }
            if (!UserRepository.IsEmailUniq(userAuth.Email!))
            {
                return new Result<AuthData, Error>(new Error("Email already in use!"));
            }
            if (!UserRepository.IsUsernameUniq(userAuth.Username!))
            {
                return new Result<AuthData, Error>(new Error("Username already in use!"));
            }

            var id = Guid.NewGuid().ToString();
            var newUser = new User
            {
                Id = id,
                Username = userAuth.Username!,
                Email = userAuth.Email!,
                Salt = AuthSaltGenerator.GetUniqueKey(32),
                Password = ""
            };
            string password = userAuth.Username + userAuth.Password + newUser.Salt;
            newUser.Password = _authService.HashPassword(password);
            UserRepository.Add(newUser);
            try
            {
                Complete();
            }
            catch
            {
                Dispose();
                return new Result<AuthData, Error>(new Error("Registery has failed!"));
            }

            return new Result<AuthData, Error>(_authService.GetAuthData(newUser.Id));
        }
        public Result<AuthData, Error> LoginUser(UserAuth userAuth)
        {

            if (!CheckIfEmailOrUsernameNotNull(userAuth))
            {
                return new Result<AuthData, Error>(new Error("Email and username empty!"));
            }

            User? loginUser = TryToGetUserByEmailOrUsername(userAuth);

            if (loginUser == null)
            {
                return new Result<AuthData, Error>(new Error("Invalid login or email!"));
            }
            if (userAuth.Password == null)
            {
                return new Result<AuthData, Error>(new Error("Invalid password!"));
            }
            string password = loginUser.Username + userAuth.Password + loginUser.Salt;

            var passwordValid = _authService.VerifyPassword(password, loginUser.Password!);
            if (!passwordValid)
            {
                return new Result<AuthData, Error>(new Error("Invalid password!"));

            }

            return new Result<AuthData, Error>(_authService.GetAuthData(loginUser.Id));

        }

        private bool ChechIfDataNotNull(UserAuth userAuth)
        {
            if (userAuth.Email == null || userAuth.Username == null || userAuth.Password == null) return false;

            return true;
        }

        private bool CheckIfEmailOrUsernameNotNull(UserAuth userAuth)
        {
            if (userAuth.Email == null && userAuth.Username == null)
            {
                return false;
            }
            return true;
        }

        private User? TryToGetUserByEmailOrUsername(UserAuth userAuth)
        {
            User? loginUser = null;
            if (userAuth.Email != null)
            {
                loginUser = UserRepository.Find(u => u.Email == userAuth.Email).FirstOrDefault();
            }
            else if (userAuth.Username != null)
            {
                loginUser = UserRepository.Find(u => u.Username == userAuth.Username).FirstOrDefault();
            }
            return loginUser;
        }
    }
}
