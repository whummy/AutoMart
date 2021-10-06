using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
   public  interface ICarRepository
    {
        Task <PagedList<Car>> GetCarsAsync(Guid brandId, CarsParameters carParameters, bool trackChanges);
        Task<Car> GetCarAsync(Guid id, bool trackChanges);
        void CreateCar(string Token, Car car);
        void DeleteCar(Car car);



    }
}
