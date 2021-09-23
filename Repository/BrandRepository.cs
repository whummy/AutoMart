using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BrandRepository : RepositoryBase<Brand>, IBrandRepository
    {
        public BrandRepository(RepositoryContext repositoryContext): base(repositoryContext)
        {
        }
        public async Task<IEnumerable<Brand>> GetAllBrandsAsync(bool trackChanges)
          {
            return await FindAll(trackChanges)
            .ToListAsync();
    }
    public async Task <Brand> GetBrandAsync(Guid brandId, bool trackChanges) =>
         await FindByCondition(b => b.Id.Equals(brandId), trackChanges)
         .SingleOrDefaultAsync();
        public void CreateBrand(Brand brand) => Create(brand);

    }
}
