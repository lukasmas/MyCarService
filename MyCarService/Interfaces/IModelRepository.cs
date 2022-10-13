using MyCarService.Models;
using MyCarService.Models.Dto;

namespace MyCarService.Interfaces
{
    public interface IModelRepository : IGenericRepository<ModelDto>
    {
        IEnumerable<CarModel> GetAllCars();
        
    }
}
