using MyCarService.Models.DatabaseModels;

namespace MyCarService.Interfaces.Repository
{
    public interface IServiceReminderRepository
    {
        public interface IMakeRepository : IGenericRepository<ServiceReminder>
        {
        }
    }
}
