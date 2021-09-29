using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BrandRepository : RepositoryBase<Brand>, IBrandRepository
    {
        public BrandRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public async Task<IEnumerable<Brand>> GetAllBrandsAsync(bool trackChanges) =>
             await FindAll(trackChanges)
            .ToListAsync();

        public async Task<Brand> GetBrandAsync(Guid brandId, bool trackChanges) =>
             await FindByCondition(b => b.Id.Equals(brandId), trackChanges)
             .SingleOrDefaultAsync();
        public void CreateBrand(Guid userId, Brand brand)
        {
            brand.UserId = userId;
            Create(brand);
        }            
           
        public async Task<IEnumerable<Brand>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) =>
          await FindByCondition(x => ids.Contains(x.Id), trackChanges)
          .ToListAsync();
        public void DeleteBrand(Brand brand)
        {
            Delete(brand);
        }

    }
}
