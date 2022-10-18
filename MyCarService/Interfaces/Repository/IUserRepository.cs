using MyCarService.Models.DatabaseModels;

namespace MyCarService.Interfaces.Repository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public bool IsEmailUniq(string email);

        public bool IsUsernameUniq(string username);
    }
}
