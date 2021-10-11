using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
   public interface IBrandRepository
    {
        Task<PagedList<Brand>> GetAllBrandsAsync(BrandParameters brandParameters, bool trackChanges);
        Task<Brand> GetBrandAsync(Guid brandId, bool trackChanges);
        void CreateBrand( Brand brand);
        Task<IEnumerable<Brand>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        void DeleteBrand(Brand brand);
    }
}
