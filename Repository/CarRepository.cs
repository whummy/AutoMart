using Contracts;
using Entities;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class CarRepository: RepositoryBase<Car>, ICarRepository
    { 
        public CarRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public async Task<PagedList<Car>> GetCarsAsync(Guid brandId, CarsParameters carParameters, bool trackChanges)
        {
            var cars = await FindByCondition(c => c.BrandId.Equals(brandId), trackChanges)
                 .FilterCars(carParameters.MinPrice, carParameters.MaxPrice)
                 .Search(carParameters.Search)
                 .Sort(carParameters.OrderBy)
                .OrderBy(c => c.ModelName)
                 .ToListAsync();

            return PagedList<Car>
             .ToPagedList(cars, carParameters.PageNumber,carParameters.PageSize);
        }

        public async Task<Car> GetCarAsync(Guid id, bool trackChanges) =>
         await FindByCondition(c => c.Id.Equals(id), trackChanges)
         .SingleOrDefaultAsync();
        public void CreateCar( Car car)
        {
            Create(car);
        }
        public void DeleteCar(Car car)
        {
            Delete(car);
        }

    }
}
