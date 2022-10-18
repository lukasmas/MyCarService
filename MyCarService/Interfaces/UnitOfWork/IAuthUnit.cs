using MyCarService.AuthServices;
using MyCarService.ErrorHandling;
using MyCarService.Models.Auth;
using MyCarService.Models.DatabaseModels;

namespace MyCarService.Interfaces.UnitOfWork
{
    public interface IAuthUnit
    {
        Result<AuthData, Error> RegisterUser(UserAuth userAuth);
        Result<AuthData, Error> LoginUser(UserAuth userAuth);

    }
}
