using MyCarService.Interfaces.Repository;
using MyCarService.Models.DatabaseModels;

namespace MyCarService.Repositories
{
    public class OwnerRepository : GenericRepository<Owner>, IOwnerRepository
    {
        public OwnerRepository(MyCarServiceContext context) : base(context)
        {
        }

    }
}
