using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
   public interface IBrandRepository
    {
        Task<IEnumerable<Brand>> GetAllBrandsAsync(bool trackChanges);
        Task<Brand> GetBrandAsync(Guid brandId, bool trackChanges);
        void CreateBrand(Guid userId , Brand brand);
        Task<IEnumerable<Brand>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        void DeleteBrand(Brand brand);
    }
}
