using MyCarService.AuthServices;

namespace MyCarService.Interfaces.Auth
{
    public interface IAuthService
    {
        public AuthData GetAuthData(string id);
        public string HashPassword(string password);
        public bool VerifyPassword(string actualPassword, string hashedPassword);



    }
}
