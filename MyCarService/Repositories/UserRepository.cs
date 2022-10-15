using MyCarService.Interfaces;
using MyCarService.Models.DatabaseModels;
using System.Web.Helpers;

namespace MyCarService.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(MyCarServiceContext context) : base(context)
        {
        }

        public bool IsEmailUniq(string email)
        {
            return Find(u => u.Email == email).Count() == 0;
        }

        public bool IsUsernameUniq(string username)
        {
            return Find(u => u.Username == username).Count() == 0;
        }
    }
}
