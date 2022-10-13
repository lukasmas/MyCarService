using MyCarService.Models;
using MyCarService.Models.DatabaseModels;

namespace MyCarService.Interfaces
{
    public interface IModelRepository : IGenericRepository<Model>
    {
        IEnumerable<CarModel> GetAllCars();
        
    }
}
