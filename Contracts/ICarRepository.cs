using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
   public  interface ICarRepository
    {
        IEnumerable<Car> GetCars(Guid brandId, bool trackChanges);
        Car GetCar(Guid carId, Guid id, bool trackChanges);
        void CreateCarForBrand(Guid brandId, Car car);


    }
}
