using MyCarService.Interfaces.Repository;
using MyCarService.Models.DatabaseModels;

namespace MyCarService.Repositories
{
    public class ServiceReminderRepository : GenericRepository<ServiceReminder>, IServiceReminderRepository
    {
        public ServiceReminderRepository(MyCarServiceContext context) : base(context)
        {
        }
    }
}
