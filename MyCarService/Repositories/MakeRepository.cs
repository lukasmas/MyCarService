using Microsoft.EntityFrameworkCore;
using MyCarService.Interfaces.Repository;
using MyCarService.Models;
using MyCarService.Models.DatabaseModels;

namespace MyCarService.Repositories
{
    public class MakeRepository : GenericRepository<Make>, IMakeRepository
    {
        public MakeRepository(MyCarServiceContext context) : base(context)
        {
        }

    }
}
