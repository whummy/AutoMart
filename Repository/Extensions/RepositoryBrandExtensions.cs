using Entities.Models;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;

namespace Repository.Extensions
{
    public static class RepositoryBrandExtensions
    {
        public static IQueryable<Brand> Search(this IQueryable<Brand> brands, string Search)
        {
            if (string.IsNullOrWhiteSpace(Search))
                return brands;
            var lowerCaseTerm = Search.Trim().ToLower();
            return brands.Where(e => e.Name.ToLower().Contains(lowerCaseTerm));
        }
        public static IQueryable<Brand> Sort(this IQueryable<Brand> brands, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return brands.OrderBy(b => b.Name);
            var orderParams = orderByQueryString.Trim().Split(',');
            var propertyInfos = typeof(Brand).GetProperties(BindingFlags.Public | BindingFlags.Instance);
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
                orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {direction},");
            }

            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
            if (string.IsNullOrWhiteSpace(orderQuery))
                return brands.OrderBy(b => b.Name);
            return brands.OrderBy(orderQuery);

        }
    }
}
