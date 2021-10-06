using Entities.Models;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;

namespace Repository.Extensions
{
    public static class RepositoryCarExtension
    {
        public static IQueryable<Car> FilterCars(this IQueryable<Car> cars, uint minPrice, uint maxPrice) =>
            cars.Where(c => (c.Price >= minPrice && c.Price <= maxPrice));
        public static IQueryable<Car> Search(this IQueryable<Car> cars,
       string search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return cars;
            var lowerCaseTerm = search.Trim().ToLower();
            return cars.Where(c => c.ModelName.ToLower().Contains(lowerCaseTerm));
        }
        public static IQueryable<Car> Sort(this IQueryable<Car> cars, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return cars.OrderBy(c => c.ModelName);
            var orderParams = orderByQueryString.Trim().Split(',');
            var propertyInfos = typeof(Car).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var orderQueryBuilder = new StringBuilder();
            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;
                var propertyFromQueryName = param.Split(" ")[0];
                var objectProperty = propertyInfos.FirstOrDefault(pi =>
               pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));
                if (objectProperty == null)
                    continue;
                var direction = param.EndsWith(" desc") ? "descending" : "ascending";
                orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {direction}, ");
            }
            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
            if (string.IsNullOrWhiteSpace(orderQuery))
                return cars.OrderBy(e => e.ModelName);
            return cars.OrderBy(orderQuery);

        }
    }
}