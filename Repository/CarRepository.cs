using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CarRepository: RepositoryBase<Car>, ICarRepository
    { 
        public CarRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public IEnumerable<Car> GetCars(Guid brandId, bool trackChanges) =>
         FindByCondition(c => c.BrandId.Equals(brandId), trackChanges)
         .OrderBy(c => c.ModelName);
        public Car GetCar(Guid brandId, Guid id, bool trackChanges) =>
         FindByCondition(c => c.BrandId.Equals(brandId) && c.Id.Equals(id),trackChanges)
         .SingleOrDefault();
        public void CreateCarForBrand(Guid brandId, Car car)
        {
            car.BrandId = brandId;
            Create(car);
        }

    }
}
