using MyCarService.Interfaces.Repository;
using MyCarService.Models;
using MyCarService.Models.DatabaseModels;

namespace MyCarService.Repositories
{
    public class ModelRepository : GenericRepository<Model>, IModelRepository
    {

        public ModelRepository(MyCarServiceContext context) : base(context)
        {
        }
        public IEnumerable<CarModel> GetAllCars()
        {
            List<CarModel> carModels = new List<CarModel>();

            var result = _context.CarModel.Join(_context.CarMake, outer => outer.MakeId, inner => inner.Id, (model, make) => new { carMake = make, carModel = model }).ToList();

            foreach (var r in result)
            {
                carModels.Add(new CarModel { ModelId = r.carModel.Id, MakeName = r.carMake.Name, ModelName = r.carModel.Name });
            }

            return carModels;
        }

    }
}
