using MyCarService.Models.DatabaseModels;

namespace MyCarService.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public bool IsEmailUniq(string email);

        public bool IsUsernameUniq(string username);
    }
}
